using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReadWriteSeparate.Models;

namespace ReadWriteSeparate.DBModel
{
    public class MyDBContext : DbContext
    {
        private DBConnectionOption _readWriteOption;
        public MyDBContext(IOptionsMonitor<DBConnectionOption> options)
        {
            _readWriteOption = options.CurrentValue;
        }

        public DbContext ReadWrite()
        {
            //把链接字符串设为读写（主库）
            this.Database.GetDbConnection().ConnectionString = this._readWriteOption.WriteConnection;
            return this;
        }
        public DbContext Read()
        {
            //把链接字符串设为之读（从库）
            this.Database.GetDbConnection().ConnectionString = this._readWriteOption.ReadConnection;
            return this;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._readWriteOption.WriteConnection); //默认主库
        }
        public DbSet<SysUser> SysUser { get; set; }
    }
}
