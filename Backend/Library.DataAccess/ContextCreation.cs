using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess
{
    public class ContextCreation
    {
        public static LibraryContext GetMemoryContext(string nameBd) {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            return new LibraryContext(GetMemoryConfig(builder, nameBd));
        }

        private static DbContextOptions GetMemoryConfig(DbContextOptionsBuilder builder, string nameBd) {
            builder.UseInMemoryDatabase(nameBd);
            return builder.Options;
        }
    }
}