namespace BlazorEcommerce.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Product>()
            .HasData(
                new Product
                {
                    Id = 1,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Description =
                        "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                    Price = 9.99m
                },
                new Product
                {
                    Id = 2,
                    Title = "Ready Player One",
                    Description =
                        @"Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune.",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                    Price = 7.99m
                },
                new Product
                {
                    Id = 3,
                    Title = "1984",
                    Description =
                        "Nineteen Eighty-Four (also published as 1984) is a dystopian social science fiction novel and cautionary tale by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the authoritarian state in the novel on Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within societies and the ways in which they can be manipulated.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg",
                    Price = 6.99m
                },
                new Product
                {
                    Id = 4,
                    Title = "The Idiot",
                    Description =
                        "The Idiot is a novel by the 19th-century Russian author Fyodor Dostoevsky. It was first published serially in the journal The Russian Messenger in 1868–69.",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/7/7b/Fyodor_Dostoyevsky_manuscript_and_drawing_06.jpg",
                    Price = 10.99m
                },
                new Product
                {
                    Id = 5,
                    Title = "Gone with the Wind",
                    Description =
                        "Gone with the Wind is a novel by American writer Margaret Mitchell, first published in 1936. The story is set in Clayton County and Atlanta, both in Georgia, during the American Civil War and Reconstruction Era.",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/en/6/6b/Gone_with_the_Wind_cover.jpg",
                    Price = 13.99m
                },
                new Product
                {
                    Id = 6,
                    Title = "How to Scam People Online",
                    Description =
                        "The perfect guide for teaching you how to scam people online. You will also learn how to avoid being scammed in the future. Also a cool gift for friends and family.",
                    ImageUrl = "https://m.media-amazon.com/images/I/41KQH5d60WL.jpg",
                    Price = 6.66m
                },
                new Product
                {
                    Id = 7,
                    Title = "War and Peace",
                    Description =
                        "War and Peace is a literary work by Russian author Leo Tolstoy. Set during the Napoleonic Wars, the work mixes fictional narrative with chapters on history and philosophy. First published serially beginning in 1865, the work was rewritten and published in its entirety in 1869",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/a/af/Tolstoy_-_War_and_Peace_-_first_edition%2C_1869.jpg",
                    Price = 7.75m
                },
                new Product
                {
                    Id = 8,
                    Title = "Les Miserables",
                    Description =
                        "Les Misérables is a French historical novel by Victor Hugo, first published in 1862, that is considered one of the greatest novels of the 19th century. Les Misérables has been popularized through numerous adaptations for film, television and the stage, including a musical.",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/f/fd/Monsieur_Madeleine_par_Gustave_Brion.jpg",
                    Price = 6.68m
                }
            );
    }

    public DbSet<Product> Products { get; set; }
}
