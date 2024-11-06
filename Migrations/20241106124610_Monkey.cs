using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MonkeyMon_Blazor.Migrations
{
    /// <inheritdoc />
    public partial class Monkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    HealthPoints = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monkeys", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Monkeys",
                columns: new[] { "Id", "Attack", "Defense", "Description", "HealthPoints", "KnownFrom", "Name", "SpecialAttack", "SpecialDefense", "Speed" },
                values: new object[,]
                {
                    { new Guid("008db3ac-ec58-4231-a814-279c0a8beec9"), 262, 472, null, 713, "Fantastic Cotton Soap", "Noble", 202, 452, 260 },
                    { new Guid("00abb8df-d769-4a43-aca2-0cbb1b6fa104"), 589, 420, null, 296, "Rustic Rubber Towels", "Brain", 574, 643, 327 },
                    { new Guid("0927d600-0d64-43d8-a044-2963ab7f5c51"), 554, 96, null, 98, "Gorgeous Soft Mouse", "Ines", 296, 215, 225 },
                    { new Guid("0b8e85d9-84d9-48ad-9ec5-7f6091d45ceb"), 532, 548, null, 58, "Gorgeous Concrete Tuna", "Rey", 350, 416, 410 },
                    { new Guid("0bc3f7c6-a582-44bd-8c58-58a03536c85e"), 404, 496, null, 429, "Handmade Granite Ball", "Barrett", 570, 247, 732 },
                    { new Guid("0be361ac-4806-4bda-98cc-f4129847da52"), 166, 146, null, 499, "Intelligent Concrete Keyboard", "Victor", 170, 171, 163 },
                    { new Guid("0c905979-8a8d-4fc9-88bc-899c3fec0181"), 5, 57, null, 656, "Licensed Fresh Chicken", "Krista", 3, 76, 398 },
                    { new Guid("10b6ea26-b45f-49a9-b71b-64af46e34df5"), 2, 620, null, 22, "Unbranded Cotton Chicken", "Bertrand", 23, 338, 348 },
                    { new Guid("16a4cb7b-5da5-428c-89bb-eb0f8c3236a2"), 36, 583, null, 107, "Handmade Plastic Keyboard", "Wilburn", 217, 236, 528 },
                    { new Guid("195801a5-c8c9-45dd-bcee-2a18fc3aefce"), 105, 122, null, 694, "Tasty Fresh Bike", "Haley", 458, 561, 476 },
                    { new Guid("1cb3d99a-3942-4f92-92f3-d7cd0c37f18f"), 117, 475, null, 82, "Awesome Granite Gloves", "Antonio", 518, 190, 774 },
                    { new Guid("1fc91f98-0b97-4dcc-9c7c-8b5a50dcc9fa"), 460, 475, null, 67, "Handcrafted Metal Fish", "Enrico", 491, 225, 113 },
                    { new Guid("26127784-a9cf-4557-9f8e-95cfe83f2e52"), 594, 419, null, 228, "Gorgeous Plastic Car", "Alanna", 367, 11, 238 },
                    { new Guid("2670328e-4ebe-4569-b1c1-cedaf861ef63"), 384, 144, null, 497, "Fantastic Frozen Soap", "Furman", 324, 228, 489 },
                    { new Guid("26a2f697-6afa-403d-88e7-2bb259e79951"), 391, 379, null, 647, "Intelligent Fresh Computer", "Broderick", 411, 137, 335 },
                    { new Guid("2af195a2-2fba-4bad-8add-c50b98901668"), 721, 159, null, 48, "Unbranded Wooden Bacon", "Willie", 551, 229, 519 },
                    { new Guid("2f61ca8c-3c9a-4d0b-915d-08ad7e70e1a9"), 495, 236, null, 623, "Intelligent Plastic Shirt", "Adriana", 544, 17, 532 },
                    { new Guid("37365d47-ca47-4027-b540-7384be5ff740"), 259, 499, null, 141, "Tasty Soft Tuna", "Eric", 133, 105, 516 },
                    { new Guid("375b2145-8f64-4b63-8e1a-b7f5b4d0a97c"), 539, 530, null, 662, "Incredible Granite Computer", "Dana", 401, 278, 661 },
                    { new Guid("39a7728a-cef0-408e-be8f-737e53c07b14"), 7, 482, null, 242, "Unbranded Plastic Chair", "Bulah", 57, 639, 742 },
                    { new Guid("3fd57887-ec57-414b-945e-2731f82ec813"), 199, 549, null, 648, "Tasty Plastic Bike", "Floyd", 373, 292, 818 },
                    { new Guid("406e54df-3e18-473b-9376-efac2262aceb"), 89, 357, null, 0, "Gorgeous Fresh Chicken", "Keshaun", 566, 61, 732 },
                    { new Guid("45fcf42a-9929-4266-a843-9ca42d78d16f"), 395, 317, null, 94, "Incredible Metal Car", "Michele", 470, 379, 840 },
                    { new Guid("5365d73b-6c32-4d68-b9a5-ddaebb01d832"), 200, 76, null, 19, "Refined Steel Tuna", "Trenton", 231, 255, 641 },
                    { new Guid("548750ba-7901-43f7-b579-86b18c2b793d"), 527, 283, null, 411, "Generic Granite Salad", "Scottie", 25, 323, 357 },
                    { new Guid("5653e460-1d0f-4f1e-8b70-14e75d899022"), 573, 111, null, 174, "Handcrafted Cotton Hat", "Rod", 550, 397, 544 },
                    { new Guid("5e4350f2-399c-4c61-9ec1-b569b7938b00"), 99, 274, null, 105, "Sleek Cotton Bike", "Princess", 357, 251, 330 },
                    { new Guid("608e767a-23a4-469c-b478-4e08f4c1abc5"), 569, 387, null, 157, "Ergonomic Plastic Shirt", "Viola", 84, 99, 492 },
                    { new Guid("62a4990a-344e-4d30-b44c-3fa827d489a5"), 694, 384, null, 71, "Generic Rubber Chicken", "Cheyenne", 591, 506, 254 },
                    { new Guid("63491d0d-7b79-4e64-aff7-345377cf1cde"), 538, 446, null, 422, "Fantastic Wooden Shirt", "Laron", 108, 475, 248 },
                    { new Guid("6388835c-e32e-42a8-9102-9b5512bdbb7e"), 216, 204, null, 447, "Tasty Metal Tuna", "Pietro", 568, 571, 87 },
                    { new Guid("6455dca6-931e-45a4-8667-382321d2b884"), 129, 602, null, 91, "Unbranded Plastic Chips", "Sammy", 370, 335, 364 },
                    { new Guid("64a21261-5795-49f1-8bf4-13539f9b90d3"), 189, 375, null, 33, "Ergonomic Fresh Pants", "Cleveland", 159, 117, 367 },
                    { new Guid("6806c850-8be1-44ca-8c36-d069ef28e6b5"), 596, 84, null, 424, "Generic Wooden Gloves", "Valentina", 603, 172, 235 },
                    { new Guid("70241048-7fd1-465c-bdbc-76251a62ea8c"), 706, 247, null, 229, "Handcrafted Frozen Keyboard", "Emma", 72, 427, 352 },
                    { new Guid("75bef2b3-aca1-4daa-b720-0095a8080b59"), 124, 238, null, 244, "Refined Rubber Chips", "Freida", 495, 40, 385 },
                    { new Guid("76c78e71-4fc5-4ec6-bc84-963fb0f2f6f3"), 221, 127, null, 319, "Awesome Granite Chair", "Deion", 23, 335, 248 },
                    { new Guid("797f95ca-b683-4db6-9df7-2633d8cd2a4b"), 529, 165, null, 119, "Tasty Steel Chips", "Rae", 513, 150, 715 },
                    { new Guid("84744404-4196-4ddd-ba66-fd2f052b9225"), 279, 261, null, 62, "Incredible Soft Gloves", "Ebony", 63, 416, 207 },
                    { new Guid("84f6c517-d09b-42a2-b102-67b7d3d57c0c"), 681, 638, null, 654, "Refined Rubber Bike", "Zelma", 224, 115, 271 },
                    { new Guid("8b7691f3-ad5c-4bbe-aacc-4d3b72bc6362"), 155, 487, null, 147, "Handcrafted Frozen Salad", "Mohamed", 569, 225, 448 },
                    { new Guid("8d649662-1aaf-4cd4-a97a-4a29e08686ab"), 150, 605, null, 653, "Ergonomic Wooden Soap", "Jorge", 22, 94, 478 },
                    { new Guid("9117e36a-4492-41e6-a3a7-5289278517f0"), 517, 120, null, 406, "Tasty Steel Sausages", "Neal", 225, 13, 33 },
                    { new Guid("94156dd6-9533-4274-8a9f-3fe26c0fe44a"), 216, 138, null, 647, "Awesome Fresh Table", "Eduardo", 88, 276, 494 },
                    { new Guid("941ff88d-7986-4e21-8689-5b8fc2ce3b41"), 53, 594, null, 706, "Practical Rubber Table", "Willa", 176, 562, 162 },
                    { new Guid("9825db62-e2eb-4dd4-8a2e-b3838f481250"), 316, 466, null, 687, "Gorgeous Steel Car", "Antonia", 444, 512, 369 },
                    { new Guid("9ab33beb-5b58-423e-91a0-beb52d4f899f"), 45, 231, null, 193, "Incredible Metal Pants", "Nicklaus", 542, 6, 442 },
                    { new Guid("9ba64ea9-12fc-421f-a087-a6d2dc4b3a71"), 687, 163, null, 278, "Intelligent Fresh Tuna", "Vincenza", 492, 453, 488 },
                    { new Guid("9c61cc7e-cf26-4eb2-a954-b60663e44dbc"), 637, 637, null, 669, "Generic Concrete Towels", "Tracey", 16, 330, 695 },
                    { new Guid("a014e519-710c-4761-b3e5-e6b3e4b9a830"), 227, 341, null, 546, "Rustic Steel Pants", "Alvah", 272, 403, 845 },
                    { new Guid("a07df502-8907-4375-97f4-5e5b85213118"), 330, 460, null, 193, "Intelligent Steel Car", "Reilly", 273, 214, 604 },
                    { new Guid("a881e684-0b4f-45bf-8d70-db6233b3fc97"), 342, 2, null, 66, "Rustic Wooden Gloves", "Ettie", 367, 24, 376 },
                    { new Guid("a959eee9-6022-482c-af42-87f24ace4053"), 203, 363, null, 151, "Awesome Steel Pizza", "Krystal", 8, 535, 289 },
                    { new Guid("ab2da342-78e1-4aa6-bedd-074d55b18e68"), 428, 355, null, 121, "Refined Granite Bike", "Rashawn", 386, 469, 126 },
                    { new Guid("b56957b1-3579-4b73-9911-205779049fa2"), 250, 571, null, 363, "Sleek Frozen Tuna", "Jaleel", 302, 575, 757 },
                    { new Guid("bacdc38d-c6d5-45f3-919d-9e838e27cfdb"), 399, 461, null, 377, "Unbranded Cotton Soap", "Nakia", 299, 334, 774 },
                    { new Guid("bcbd6758-49ab-46f4-8e85-fbd1b8e989a9"), 388, 129, null, 385, "Incredible Plastic Chicken", "Ian", 523, 49, 232 },
                    { new Guid("bd0c8d06-8556-492e-932b-bc515b9a91fe"), 456, 26, null, 616, "Unbranded Wooden Chips", "Caleb", 501, 595, 424 },
                    { new Guid("c083445b-0563-487f-9476-15347c509887"), 558, 66, null, 3, "Licensed Cotton Shoes", "Emery", 475, 390, 724 },
                    { new Guid("c1c56375-d838-4279-9bbf-88a788bf3379"), 223, 308, null, 280, "Ergonomic Concrete Hat", "Felton", 34, 304, 673 },
                    { new Guid("c246c1bf-bf90-42e0-84a9-27203dcdba18"), 599, 31, null, 98, "Awesome Wooden Chicken", "Einar", 570, 648, 475 },
                    { new Guid("c574d7ad-911a-4a86-84be-7b3e3725ca15"), 415, 170, null, 299, "Incredible Fresh Hat", "Keyon", 369, 465, 389 },
                    { new Guid("c6dece1e-1b3f-4d2f-bde6-1f15cbe7b079"), 702, 533, null, 395, "Tasty Concrete Chair", "Felipe", 97, 641, 742 },
                    { new Guid("c936eb40-1b4f-4e60-a863-b896b157acce"), 578, 296, null, 581, "Sleek Cotton Tuna", "Alison", 289, 511, 647 },
                    { new Guid("d0e4570c-3576-4bb3-889e-9e3fde36375e"), 284, 15, null, 602, "Gorgeous Rubber Soap", "Leon", 100, 129, 198 },
                    { new Guid("d45917c6-d8e2-494e-aa27-cf34c874b8e8"), 376, 82, null, 411, "Gorgeous Fresh Mouse", "Evert", 589, 305, 181 },
                    { new Guid("d4a6a17d-88d2-4c0c-b198-cb57f74740e5"), 624, 221, null, 101, "Intelligent Soft Soap", "Breanna", 390, 565, 128 },
                    { new Guid("db7ecf6a-a829-4213-9373-e3268bdb5005"), 464, 198, null, 684, "Licensed Cotton Ball", "Tiffany", 421, 261, 612 },
                    { new Guid("e0cb159d-fd7f-4d9f-bc65-3fd3bfad6f96"), 350, 248, null, 531, "Unbranded Plastic Computer", "Deontae", 409, 599, 341 },
                    { new Guid("e168e4e0-99bb-442e-8d1d-8cabe324ecba"), 499, 275, null, 241, "Licensed Soft Bike", "Mike", 395, 106, 409 },
                    { new Guid("e262c294-a557-46b7-acd8-e32d669b6ac7"), 135, 73, null, 22, "Refined Steel Car", "Annette", 608, 622, 252 },
                    { new Guid("e3c033d3-c1f5-4def-969b-08e80984a33d"), 141, 63, null, 66, "Rustic Plastic Mouse", "Ally", 9, 16, 193 },
                    { new Guid("e90355d6-7127-4a02-bbef-755e58897552"), 554, 449, null, 186, "Gorgeous Metal Car", "Kenyon", 168, 460, 362 },
                    { new Guid("e9c8b1d2-e257-4a1c-8eac-d2698cffa113"), 679, 352, null, 253, "Handmade Fresh Chips", "Agustin", 332, 647, 159 },
                    { new Guid("ead6ff21-2953-4a47-ac83-c05aac20609c"), 323, 451, null, 81, "Unbranded Concrete Fish", "Dane", 419, 198, 767 },
                    { new Guid("ee152b7e-c961-41fb-a242-ae865586e3b1"), 206, 331, null, 516, "Awesome Metal Shoes", "Declan", 521, 517, 740 },
                    { new Guid("f10eea79-7948-4922-a0fb-61e29a02f27f"), 367, 510, null, 395, "Handcrafted Metal Cheese", "Dixie", 211, 114, 805 },
                    { new Guid("f641afa6-f533-49a2-bbee-f1919316a080"), 529, 469, null, 707, "Licensed Cotton Shoes", "June", 508, 292, 112 },
                    { new Guid("f837ddd9-ec72-4569-b061-017e7ec2af0b"), 704, 126, null, 112, "Practical Granite Tuna", "Brent", 577, 396, 237 },
                    { new Guid("fa08f5c0-8ab9-443b-ab17-d0efdf702f1d"), 84, 170, null, 44, "Sleek Steel Shirt", "Janessa", 54, 434, 68 },
                    { new Guid("fb52b819-1875-44e2-930a-7dc89704759c"), 507, 636, null, 654, "Sleek Granite Chair", "Johann", 341, 205, 405 },
                    { new Guid("fcefc4dd-dbf8-423b-a681-a03b4543f1d5"), 680, 84, null, 374, "Handcrafted Wooden Chicken", "Hailey", 260, 350, 800 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monkeys");
        }
    }
}
