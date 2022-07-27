namespace ReadWriteSeparate.DBModel
{
    public class SysUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
