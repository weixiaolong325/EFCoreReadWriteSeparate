using Microsoft.EntityFrameworkCore;

namespace ReadWriteSeparate.DBModel
{
    /// <summary>
    /// 拓展方法
    /// </summary>
    public static class DbContextExtend
    {
        /// <summary>
        /// 只读
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DbContext Read(this DbContext dbContext)
        {
            if (dbContext is MyDBContext)
            {
                return ((MyDBContext)dbContext).Read();
            }
            else
                throw new Exception();
        }
        /// <summary>
        /// 读写
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DbContext ReadWrite(this DbContext dbContext)
        {
            if (dbContext is MyDBContext)
            {
                return ((MyDBContext)dbContext).ReadWrite();
            }
            else
                throw new Exception();
        }
    }
}
