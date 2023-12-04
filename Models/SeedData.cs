using Microsoft.EntityFrameworkCore;
using TSLAssignment.Data;

namespace TSLAssignment.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TSLAssignmentContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TSLAssignmentContext>>()))
            {
                // Look for any movies.
                if (context.TextWrapper.Any())
                {
                    return;   // DB has been seeded
                }
                context.TextWrapper.AddRange(
                    new TextWrapper
                    {
                        Text = "When Harry Met Sally",
                        CreatedTime = DateTime.Parse("1989-2-12"),
                        EnableReversed = false,
       
                    },
                    new TextWrapper
                    {
                        Text = "Ghostbusters ",
                        CreatedTime = DateTime.Parse("1984-3-13"),
                        EnableReversed = false,
                       
                    },
                    new TextWrapper
                    {
                        Text = "Ghostbusters 2",
                        CreatedTime = DateTime.Parse("1986-2-23"),
                        EnableReversed = true,
                       
                    }
                );
                context.SaveChanges();
            }
        }
    }

}
