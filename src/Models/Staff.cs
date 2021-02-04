using System;

namespace Hrs
{
    public class Staff
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Ic { get; set; }    
        public string Email { get; set; }    
        public string StaffId { get; set; }
        public bool IsPermanent { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedById { get; set; }
        public int ModifiedById { get; set; }

        public override string ToString() => $"{Title} {Name}";
    }
}