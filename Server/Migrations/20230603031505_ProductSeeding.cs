using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorEcommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    {
                        1,
                        "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
                        "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                        9.99m,
                        "The Hitchhiker's Guide to the Galaxy"
                    },
                    {
                        2,
                        "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune.",
                        "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                        7.99m,
                        "Ready Player One"
                    },
                    {
                        3,
                        "Nineteen Eighty-Four (also published as 1984) is a dystopian social science fiction novel and cautionary tale by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the authoritarian state in the novel on Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within societies and the ways in which they can be manipulated.",
                        "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg",
                        6.99m,
                        "1984"
                    },
                    {
                        4,
                        "The Idiot is a novel by the 19th-century Russian author Fyodor Dostoevsky. It was first published serially in the journal The Russian Messenger in 1868–69.",
                        "https://upload.wikimedia.org/wikipedia/commons/7/7b/Fyodor_Dostoyevsky_manuscript_and_drawing_06.jpg",
                        10.99m,
                        "The Idiot"
                    },
                    {
                        5,
                        "Gone with the Wind is a novel by American writer Margaret Mitchell, first published in 1936. The story is set in Clayton County and Atlanta, both in Georgia, during the American Civil War and Reconstruction Era.",
                        "https://upload.wikimedia.org/wikipedia/en/6/6b/Gone_with_the_Wind_cover.jpg",
                        13.99m,
                        "Gone with the Wind"
                    },
                    {
                        6,
                        "The perfect guide for teaching you how to scam people online. You will also learn how to avoid being scammed in the future. Also a cool gift for friends and family.",
                        "https://m.media-amazon.com/images/I/41KQH5d60WL.jpg",
                        6.66m,
                        "How to Scam People Online"
                    },
                    {
                        7,
                        "War and Peace is a literary work by Russian author Leo Tolstoy. Set during the Napoleonic Wars, the work mixes fictional narrative with chapters on history and philosophy. First published serially beginning in 1865, the work was rewritten and published in its entirety in 1869",
                        "https://upload.wikimedia.org/wikipedia/commons/a/af/Tolstoy_-_War_and_Peace_-_first_edition%2C_1869.jpg",
                        7.75m,
                        "War and Peace"
                    },
                    {
                        8,
                        "Les Misérables is a French historical novel by Victor Hugo, first published in 1862, that is considered one of the greatest novels of the 19th century. Les Misérables has been popularized through numerous adaptations for film, television and the stage, including a musical.",
                        "https://upload.wikimedia.org/wikipedia/commons/f/fd/Monsieur_Madeleine_par_Gustave_Brion.jpg",
                        6.68m,
                        "Les Miserables"
                    }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: 2);

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: 3);

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: 4);

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: 5);

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: 6);

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: 7);

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: 8);
        }
    }
}
