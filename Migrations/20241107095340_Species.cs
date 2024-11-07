using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MonkeyMon_Blazor.Migrations
{
    /// <inheritdoc />
    public partial class Species : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Locations = table.Column<string>(type: "text", nullable: false),
                    Taxonomy = table.Column<string>(type: "text", nullable: false),
                    Characteristics = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monkeys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    KnownFrom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Attack = table.Column<int>(type: "integer", nullable: true),
                    Defense = table.Column<int>(type: "integer", nullable: true),
                    SpecialAttack = table.Column<int>(type: "integer", nullable: true),
                    SpecialDefense = table.Column<int>(type: "integer", nullable: true),
                    Speed = table.Column<int>(type: "integer", nullable: true),
                    HealthPoints = table.Column<int>(type: "integer", nullable: true),
                    SpeciesId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monkeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monkeys_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Monkeys",
                columns: new[] { "Id", "Attack", "Defense", "Description", "HealthPoints", "KnownFrom", "Name", "SpecialAttack", "SpecialDefense", "SpeciesId", "Speed" },
                values: new object[,]
                {
                    { new Guid("02434c2a-b52a-475e-9a7f-e046d98ec855"), 320, 269, null, 397, "Handcrafted Cotton Salad", "Frieda", 75, 501, null, 621 },
                    { new Guid("077d575f-0771-4ce0-b4c9-1f28b9ffc791"), 26, 180, null, 290, "Gorgeous Metal Ball", "Penelope", 20, 446, null, 764 },
                    { new Guid("0c71a292-d9f2-45dc-b19e-34c821782d7a"), 128, 508, null, 152, "Unbranded Frozen Salad", "Eva", 142, 54, null, 605 },
                    { new Guid("0da1b390-3ee1-4722-b310-d0463a3d797f"), 307, 195, null, 704, "Generic Cotton Tuna", "Leon", 207, 61, null, 852 },
                    { new Guid("0f85bc8d-2be1-490e-8f1b-4562af7f1963"), 266, 548, null, 273, "Unbranded Steel Table", "Modesta", 91, 71, null, 74 },
                    { new Guid("0fbad9fe-1618-403b-81f9-9c856b39336d"), 667, 88, null, 539, "Small Metal Keyboard", "Kelsi", 156, 449, null, 374 },
                    { new Guid("0fece278-06a5-4360-9302-157fedbe4771"), 175, 188, null, 712, "Intelligent Cotton Bike", "Jamarcus", 545, 643, null, 657 },
                    { new Guid("10ea61a5-ae0f-4d3f-b4b1-4ef9f9fefb72"), 484, 365, null, 26, "Tasty Rubber Fish", "Priscilla", 93, 103, null, 836 },
                    { new Guid("12b9a929-3edc-4b79-8c8d-52e8d767ae44"), 404, 260, null, 360, "Handcrafted Fresh Tuna", "Tina", 321, 354, null, 462 },
                    { new Guid("160021fd-c698-4465-bc59-4fe39eb3d5f7"), 619, 41, null, 557, "Small Concrete Towels", "Joaquin", 241, 330, null, 419 },
                    { new Guid("19ba97a5-f7ba-4ed2-9090-8590fe4cc0ca"), 624, 554, null, 146, "Ergonomic Plastic Bacon", "Fiona", 442, 71, null, 174 },
                    { new Guid("1ad30b09-0d2e-42e3-92bd-ee7552c57842"), 395, 159, null, 385, "Fantastic Fresh Pizza", "Heaven", 356, 502, null, 496 },
                    { new Guid("2271a4eb-4d90-4f5a-8d46-a4305c543f8e"), 423, 507, null, 55, "Ergonomic Rubber Tuna", "Okey", 170, 162, null, 622 },
                    { new Guid("25a2f341-7507-4161-a536-1c5b29230684"), 21, 180, null, 158, "Practical Rubber Fish", "Sister", 413, 8, null, 714 },
                    { new Guid("2863a05f-30bf-4c0f-91bd-0490e4778545"), 336, 42, null, 692, "Practical Concrete Towels", "Aylin", 569, 160, null, 374 },
                    { new Guid("2a9d1ab9-d3b6-426a-a5c0-16d1c1c17d3d"), 52, 449, null, 147, "Gorgeous Fresh Soap", "Era", 428, 296, null, 125 },
                    { new Guid("2aea6c54-b5b0-4c9c-b090-a90265c6baf4"), 607, 223, null, 281, "Unbranded Soft Fish", "Ines", 108, 240, null, 201 },
                    { new Guid("2af24052-147d-444c-bbe2-dc12e8641ae4"), 284, 269, null, 222, "Refined Cotton Bike", "Marisa", 497, 54, null, 651 },
                    { new Guid("2b8c9038-b000-4fb0-929a-101eb751f204"), 180, 442, null, 47, "Intelligent Rubber Chair", "Junius", 511, 175, null, 99 },
                    { new Guid("2f00264c-63b0-47ad-9609-3dcf925cc88a"), 720, 488, null, 151, "Small Soft Mouse", "Thurman", 16, 529, null, 700 },
                    { new Guid("31939275-0234-4ff7-92a2-09ee7d12634e"), 712, 403, null, 536, "Rustic Rubber Towels", "Lempi", 117, 366, null, 577 },
                    { new Guid("359c8461-1e1e-4546-bf1c-02e9447bb729"), 624, 515, null, 435, "Small Steel Cheese", "Lourdes", 129, 155, null, 233 },
                    { new Guid("39b6c3c3-3f78-42e7-9e7d-e997d2b7e423"), 70, 392, null, 459, "Generic Frozen Cheese", "Maryam", 97, 344, null, 226 },
                    { new Guid("3a16f152-549f-44aa-869b-ccc1d68a4b0a"), 707, 64, null, 515, "Unbranded Plastic Salad", "Veronica", 376, 416, null, 520 },
                    { new Guid("3a8213fb-278f-4644-aec3-49e90309b83b"), 113, 413, null, 279, "Incredible Fresh Pizza", "Taryn", 59, 259, null, 652 },
                    { new Guid("3b08993c-a91d-48ff-bfea-8299f1314adb"), 312, 447, null, 165, "Refined Soft Keyboard", "Anahi", 267, 56, null, 381 },
                    { new Guid("40263c72-835b-4b22-9037-17cfe641dc22"), 215, 38, null, 129, "Licensed Plastic Mouse", "Tyrel", 110, 605, null, 718 },
                    { new Guid("403f79a4-606c-462f-94a9-d90b3ccbcb71"), 61, 259, null, 654, "Fantastic Wooden Salad", "Vance", 607, 146, null, 795 },
                    { new Guid("4acd77f2-7fb0-4893-bbab-f36458b2c5e0"), 77, 444, null, 495, "Ergonomic Cotton Cheese", "Mireille", 333, 161, null, 87 },
                    { new Guid("4ae45a15-96e0-4b5b-9906-95b12603746d"), 45, 211, null, 89, "Tasty Cotton Pants", "Katelyn", 104, 384, null, 91 },
                    { new Guid("4df05b80-5c5a-49a9-8ffb-5fbf4100c09b"), 229, 454, null, 49, "Licensed Steel Computer", "Conner", 475, 361, null, 61 },
                    { new Guid("4faadc77-d370-4684-9e52-7e8c2724d83d"), 559, 282, null, 3, "Incredible Frozen Chair", "Mia", 156, 370, null, 291 },
                    { new Guid("54facaa0-811b-44d9-bc4f-b949a1baa3d1"), 543, 598, null, 35, "Handcrafted Metal Bike", "Izaiah", 57, 535, null, 296 },
                    { new Guid("5649b087-70d2-40b4-b55f-cf59dd8cdf98"), 196, 446, null, 541, "Ergonomic Plastic Salad", "Rafael", 151, 146, null, 511 },
                    { new Guid("57ceac89-c75b-42da-a591-227b3d890532"), 657, 70, null, 70, "Handmade Fresh Soap", "Ruth", 561, 478, null, 349 },
                    { new Guid("5dba6f82-7994-4df7-82de-5b354ae76f43"), 403, 397, null, 108, "Awesome Metal Hat", "Keaton", 571, 480, null, 590 },
                    { new Guid("5dde1a39-50e4-44cc-8234-024b9c719613"), 230, 502, null, 333, "Rustic Fresh Towels", "Brando", 293, 290, null, 435 },
                    { new Guid("61ff2fa8-3d38-43ff-8bd3-224bccf9c8ee"), 307, 48, null, 492, "Tasty Wooden Mouse", "Sven", 350, 408, null, 205 },
                    { new Guid("62fd8335-89d2-44d7-ac3e-7e6a4528fd2a"), 182, 531, null, 246, "Fantastic Wooden Bike", "Tristian", 594, 514, null, 751 },
                    { new Guid("6909eb90-c59b-4582-b48b-04d35cdd897b"), 9, 371, null, 177, "Practical Frozen Table", "Albin", 546, 542, null, 567 },
                    { new Guid("6aadb1ba-b31f-44e5-879c-585e034f0634"), 362, 458, null, 440, "Gorgeous Metal Cheese", "Eldora", 485, 638, null, 770 },
                    { new Guid("6d67fb36-092d-4f3b-9fe8-ca41458a5549"), 132, 265, null, 472, "Refined Steel Bacon", "Gideon", 73, 146, null, 804 },
                    { new Guid("6ff27cc6-aed6-40e6-8530-29ff59e66727"), 495, 211, null, 630, "Gorgeous Metal Fish", "Emie", 597, 63, null, 181 },
                    { new Guid("74fcdffc-fd2a-4b2f-b04d-df98fa212974"), 129, 248, null, 684, "Tasty Steel Mouse", "Franz", 228, 147, null, 397 },
                    { new Guid("781d48c2-1e4f-4f8a-ac5d-73d35ebe2ba2"), 447, 614, null, 387, "Small Metal Mouse", "Alejandrin", 279, 232, null, 712 },
                    { new Guid("79546b53-f86c-4b95-b792-f60808503545"), 160, 153, null, 377, "Rustic Granite Chips", "Thaddeus", 502, 380, null, 728 },
                    { new Guid("7ea984d9-c715-41ac-8cfe-36d98193c283"), 507, 233, null, 562, "Gorgeous Wooden Bike", "Clemmie", 124, 188, null, 493 },
                    { new Guid("7fd91804-89d1-449e-b28b-25145d23a5e5"), 45, 324, null, 166, "Unbranded Cotton Gloves", "Akeem", 487, 313, null, 35 },
                    { new Guid("8170878a-ea59-41e5-8882-08c4af4e7ec6"), 597, 371, null, 488, "Refined Cotton Chicken", "Dale", 461, 433, null, 648 },
                    { new Guid("82026875-2daa-4199-ab30-f78a5f139875"), 687, 259, null, 337, "Tasty Metal Soap", "Katharina", 237, 538, null, 836 },
                    { new Guid("8565b289-0f98-4c19-ac8f-49baaf50f274"), 333, 219, null, 412, "Awesome Soft Chips", "Janae", 435, 314, null, 16 },
                    { new Guid("895dbdd1-50d3-48b3-9c53-85c66c8dbf2f"), 315, 163, null, 591, "Refined Plastic Keyboard", "Lina", 81, 433, null, 79 },
                    { new Guid("8ef29eed-d630-4a67-8c0f-68fe96c00668"), 659, 586, null, 449, "Refined Concrete Car", "Clement", 231, 487, null, 813 },
                    { new Guid("8fb60518-0c89-4682-9805-4c601a02e69c"), 352, 190, null, 646, "Rustic Wooden Keyboard", "Rita", 534, 646, null, 665 },
                    { new Guid("9ae78d7d-41df-4c77-b6db-deecb391f554"), 31, 408, null, 419, "Fantastic Rubber Tuna", "Lucius", 295, 115, null, 779 },
                    { new Guid("9b2e7c21-a0c8-4128-b05a-cf72301198f9"), 546, 570, null, 645, "Intelligent Wooden Cheese", "Ariel", 419, 114, null, 773 },
                    { new Guid("a332c11a-2c33-4f0f-b2b9-67630c5b5759"), 399, 164, null, 352, "Rustic Soft Bike", "Scottie", 261, 386, null, 396 },
                    { new Guid("a3587725-0477-4b1a-8f27-bb2f95076269"), 672, 642, null, 158, "Rustic Wooden Chips", "Agnes", 108, 383, null, 47 },
                    { new Guid("a3be1baa-8948-45e0-ae61-6c4c2b981b40"), 366, 248, null, 597, "Sleek Fresh Bike", "Davion", 8, 314, null, 160 },
                    { new Guid("a53f3353-2220-4929-8fa8-f90b27c1f574"), 567, 163, null, 337, "Sleek Rubber Soap", "Olin", 166, 306, null, 555 },
                    { new Guid("a5e2b3a4-a6b9-4a1c-b48d-8cdc771c87d6"), 530, 158, null, 46, "Fantastic Fresh Bacon", "Emma", 525, 233, null, 71 },
                    { new Guid("abaf2d0c-03e8-481b-873a-698559593641"), 151, 440, null, 331, "Rustic Wooden Sausages", "Claudine", 118, 511, null, 200 },
                    { new Guid("ad1f7574-9da0-4470-bf8d-72a127d90c0a"), 559, 475, null, 182, "Generic Frozen Gloves", "Daniella", 467, 174, null, 169 },
                    { new Guid("afc19488-f374-49df-8bbf-5b10f2ab54d2"), 600, 259, null, 673, "Refined Granite Shirt", "Rowena", 480, 184, null, 578 },
                    { new Guid("b8585420-bba8-4727-bf3e-d23e76180160"), 370, 566, null, 191, "Sleek Plastic Bacon", "Evan", 476, 451, null, 569 },
                    { new Guid("c1fbc259-b81e-48e5-b9b0-bc81acd63023"), 24, 464, null, 319, "Handmade Fresh Mouse", "Myrtice", 195, 368, null, 416 },
                    { new Guid("c312c1ec-9c81-4def-bec7-e48798b79fde"), 248, 137, null, 68, "Incredible Concrete Sausages", "Dion", 431, 314, null, 482 },
                    { new Guid("c4449798-4bf3-444e-b156-982d7bde79d8"), 527, 135, null, 125, "Small Soft Bike", "Abagail", 531, 166, null, 467 },
                    { new Guid("c5d553f4-47aa-44bd-8aa7-13b341fc7a86"), 75, 269, null, 200, "Rustic Concrete Table", "Michele", 264, 191, null, 433 },
                    { new Guid("ca5597b5-dfb8-4ae6-8bfa-3885738817e6"), 202, 111, null, 149, "Handmade Rubber Sausages", "Berenice", 78, 604, null, 646 },
                    { new Guid("cb3d0f03-eb49-4611-bf7c-21b28a0dc2fc"), 383, 292, null, 604, "Gorgeous Metal Gloves", "Ada", 85, 94, null, 771 },
                    { new Guid("cbface08-5b47-4ec4-b239-039a5b266f3b"), 358, 20, null, 19, "Licensed Frozen Computer", "Mireya", 508, 285, null, 536 },
                    { new Guid("d079a89f-798e-4827-8750-c09e5516e2c5"), 644, 269, null, 167, "Gorgeous Granite Towels", "Flavio", 544, 61, null, 171 },
                    { new Guid("d1e6eda2-40e6-4378-aa63-dae2d6d8e1e0"), 714, 364, null, 396, "Licensed Plastic Tuna", "Isabelle", 545, 632, null, 67 },
                    { new Guid("d6dbcdaf-9593-404b-bfc6-76b80e1afcf5"), 154, 642, null, 462, "Intelligent Steel Bacon", "Jeffrey", 588, 84, null, 681 },
                    { new Guid("d893c490-aca8-468b-a65c-21e6cb177efe"), 700, 426, null, 277, "Handcrafted Cotton Ball", "Jules", 485, 454, null, 193 },
                    { new Guid("dc22fdb5-71f4-43d1-bb49-83e30bad9486"), 387, 615, null, 208, "Rustic Plastic Mouse", "Emilie", 456, 639, null, 808 },
                    { new Guid("df9a2ec0-a420-46d2-a6ae-55ae085cd00a"), 102, 524, null, 704, "Intelligent Wooden Chicken", "Kirstin", 233, 180, null, 18 },
                    { new Guid("dfe20b8d-43de-47f8-a269-cae227d8bbee"), 458, 571, null, 707, "Refined Rubber Shoes", "Junius", 435, 494, null, 103 },
                    { new Guid("e12281a5-5fc4-481f-b177-c0011c73340c"), 144, 251, null, 93, "Tasty Concrete Bacon", "Ola", 29, 204, null, 298 },
                    { new Guid("e856d582-bd60-4599-bc14-3014787e5dc8"), 18, 327, null, 209, "Small Metal Fish", "Elinor", 162, 38, null, 36 },
                    { new Guid("e99177a0-69da-4ee2-a0dc-0f486df1bf71"), 108, 339, null, 427, "Fantastic Fresh Mouse", "Raphael", 85, 226, null, 131 },
                    { new Guid("ea2758a8-5278-4b72-86b4-8eedaf217144"), 160, 125, null, 174, "Handmade Wooden Keyboard", "Lillie", 416, 39, null, 610 },
                    { new Guid("ea5ecd5d-71bf-424e-94b3-791c0d733452"), 528, 101, null, 272, "Rustic Frozen Pizza", "Carlie", 607, 399, null, 215 },
                    { new Guid("ef4d684e-5308-4081-a875-ce4afdea8ec1"), 23, 333, null, 69, "Incredible Fresh Shoes", "Hermann", 129, 350, null, 608 },
                    { new Guid("f18f05a2-a493-4134-b7c9-69bb6c7a7dfc"), 157, 584, null, 508, "Fantastic Concrete Sausages", "Olen", 39, 637, null, 206 },
                    { new Guid("f346d2e2-a107-4630-a767-bfc7462d057a"), 15, 621, null, 651, "Tasty Rubber Hat", "Celine", 245, 313, null, 553 },
                    { new Guid("f5a97344-3059-4970-81c8-a6f9ef2e7365"), 95, 276, null, 246, "Generic Wooden Gloves", "Lucio", 366, 333, null, 804 },
                    { new Guid("f886cc16-9ae1-4a4d-9925-e58bd3a8e9aa"), 147, 387, null, 495, "Tasty Concrete Table", "Randi", 581, 254, null, 690 },
                    { new Guid("f9f8a8c0-3455-4dfd-ace6-b9ee06d5a8ea"), 379, 405, null, 596, "Refined Cotton Computer", "Jessika", 361, 375, null, 370 },
                    { new Guid("fb5a8688-7f5d-4c3f-a3ba-b7d46363c408"), 669, 514, null, 383, "Rustic Cotton Keyboard", "Jordan", 581, 275, null, 271 },
                    { new Guid("fd8d7100-f6c0-41c8-aeb5-ce3766f293e2"), 621, 279, null, 490, "Rustic Granite Chips", "Bernadette", 67, 63, null, 415 },
                    { new Guid("ff4c35a0-6b02-435b-8c8b-a8ed874d4838"), 414, 405, null, 653, "Incredible Cotton Sausages", "Jacquelyn", 366, 360, null, 470 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monkeys_SpeciesId",
                table: "Monkeys",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monkeys");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
