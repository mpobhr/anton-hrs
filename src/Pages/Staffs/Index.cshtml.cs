using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MySqlConnector;


namespace Hrs.Pages.Staffs
{
    public class IndexModel : PageModel
    {
        readonly string _cn;
        public IndexModel(IConfiguration cfg)
        {
            _cn = cfg.GetConnectionString("mysql");
        }

        public List<Staff> Items { get; set; } 
        public Staff Item { get; set; }
        public void OnGet(int id = 0)
        {            
            var where = id == 0 ? "" : $" where id=@id";
            var sql = $"select * from staffs {where}";
            using var cn = new MySqlConnection(_cn); 
            using var cmd = new MySqlCommand(sql, cn);
            cn.Open();
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            using var reader = cmd.ExecuteReader();

            Items = new List<Staff>();
            while (reader.Read()) {
                Items.Add(new Staff {
                    Id = (int) reader["Id"],
                    Name = reader["Name"].ToString(),
                    StaffId = reader["StaffId"].ToString(), 
                });
            }
            if (id > 0)
                Item = Items.FirstOrDefault();
        }
    }
}
