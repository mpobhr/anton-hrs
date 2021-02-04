using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Hrs.Pages.Staffs
{    
    public class EditModel : PageModel
    {
        readonly string _cn;
        [BindProperty] public Staff Item { get; set; }

        public EditModel(IConfiguration cfg)
        {
            _cn = cfg.GetConnectionString("mysql");
        }

        
        public void OnGet(int id = 0)
        {            
            if (id == 0)
                return;
            using var cn = new MySqlConnection(_cn); 
            cn.Open();
            using var cmd = new MySqlCommand("select * from staffs where id=@id", cn);            
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            using var reader = cmd.ExecuteReader();
            if (reader.Read()) {
                Item = new Staff {
                    Id = (int) reader["Id"],
                    Name = reader["Name"].ToString(),
                    StaffId = reader["StaffId"].ToString(),
                };
            }
            cn.Close();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Item.Name))
                return Page();
            var sql = Item.Id == 0 ? "insert into staffs (Id, Name, StaffId) values(@Id, @Name, @StaffId)"
             : "update staffs set Name=@Name, StaffId=@StaffId where Id=@Id";
            using var cn = new MySqlConnection(_cn); 
            using var cmd = new MySqlCommand(sql, cn);
            cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = Item.Id;
            cmd.Parameters.Add("@Name", MySqlDbType.VarString).Value = Item.Name;
            cmd.Parameters.Add("@StaffId", MySqlDbType.VarString).Value = Item.StaffId;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            return Redirect("~/staffs");
        }
    }
}
