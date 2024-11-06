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
                    SpeciesId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    { new Guid("0023c9ff-1195-402e-ab91-7ece62861f9c"), 113, 441, null, 483, "Fantastic Frozen Gloves", "Damian", 371, 325, new Guid("00000000-0000-0000-0000-000000000000"), 138 },
                    { new Guid("07a7a734-92dd-4fb1-8c5d-c1abb49861bf"), 629, 20, null, 665, "Rustic Plastic Cheese", "Burnice", 514, 375, new Guid("00000000-0000-0000-0000-000000000000"), 558 },
                    { new Guid("07d3dc32-e73d-4629-85e7-fa31d6a4b86a"), 682, 619, null, 703, "Fantastic Plastic Chips", "Celia", 333, 79, new Guid("00000000-0000-0000-0000-000000000000"), 542 },
                    { new Guid("08d359dd-a8c1-4000-9305-0d8caa3946b4"), 208, 507, null, 6, "Ergonomic Concrete Car", "Christop", 181, 30, new Guid("00000000-0000-0000-0000-000000000000"), 244 },
                    { new Guid("09f879c8-fe67-4ed2-9ddb-5fef1f4ca8e6"), 119, 163, null, 572, "Handcrafted Plastic Fish", "Kristian", 516, 302, new Guid("00000000-0000-0000-0000-000000000000"), 71 },
                    { new Guid("0b4971fc-1e34-4fec-acb0-1fa90a5bca90"), 125, 564, null, 447, "Fantastic Soft Soap", "Werner", 320, 28, new Guid("00000000-0000-0000-0000-000000000000"), 694 },
                    { new Guid("0b6a6f96-4786-450c-a620-7e42097da7d2"), 654, 195, null, 119, "Ergonomic Plastic Salad", "Antoinette", 131, 40, new Guid("00000000-0000-0000-0000-000000000000"), 526 },
                    { new Guid("0e9f84a1-13f0-4892-a23b-f247b0fe98ef"), 660, 32, null, 246, "Licensed Metal Cheese", "Emilie", 143, 499, new Guid("00000000-0000-0000-0000-000000000000"), 284 },
                    { new Guid("11511a2b-d305-49c0-9a0d-f8d8c40957ca"), 211, 174, null, 679, "Gorgeous Concrete Keyboard", "Janelle", 20, 402, new Guid("00000000-0000-0000-0000-000000000000"), 74 },
                    { new Guid("137bd13a-ca91-43b0-8125-3bb4c4bc01f3"), 297, 362, null, 436, "Refined Steel Chicken", "Laron", 526, 440, new Guid("00000000-0000-0000-0000-000000000000"), 819 },
                    { new Guid("1a8c1659-29fb-4e90-b9ad-92b7f60f2de1"), 413, 345, null, 622, "Gorgeous Cotton Chicken", "Marlon", 564, 237, new Guid("00000000-0000-0000-0000-000000000000"), 740 },
                    { new Guid("1bc59771-4c6d-493b-a448-e7a56ce1dcaa"), 353, 322, null, 88, "Generic Concrete Bike", "Hilda", 177, 125, new Guid("00000000-0000-0000-0000-000000000000"), 367 },
                    { new Guid("1fcaa917-68c7-45bf-b249-35b267eb9e99"), 672, 367, null, 422, "Fantastic Concrete Towels", "Roderick", 421, 633, new Guid("00000000-0000-0000-0000-000000000000"), 690 },
                    { new Guid("2075688d-0317-41e8-82f7-1a15b8241586"), 141, 128, null, 96, "Practical Granite Soap", "Carolyn", 308, 77, new Guid("00000000-0000-0000-0000-000000000000"), 571 },
                    { new Guid("2274c5dc-9725-4009-b016-1f48dc90579d"), 561, 203, null, 597, "Unbranded Frozen Pizza", "Hunter", 478, 14, new Guid("00000000-0000-0000-0000-000000000000"), 559 },
                    { new Guid("2363c518-1efd-446c-abcc-808a38811869"), 334, 464, null, 662, "Gorgeous Wooden Cheese", "Violet", 369, 362, new Guid("00000000-0000-0000-0000-000000000000"), 272 },
                    { new Guid("258248d5-9ba3-4ea0-8c32-ee98f0eb759d"), 313, 555, null, 129, "Intelligent Soft Car", "Monique", 526, 484, new Guid("00000000-0000-0000-0000-000000000000"), 207 },
                    { new Guid("2915071f-d31d-40b4-9007-553106afaa2f"), 403, 322, null, 568, "Sleek Granite Computer", "Christophe", 335, 357, new Guid("00000000-0000-0000-0000-000000000000"), 21 },
                    { new Guid("32617e0d-4ceb-4d47-b162-616a3fe4cffd"), 69, 270, null, 456, "Handmade Cotton Computer", "Nichole", 460, 225, new Guid("00000000-0000-0000-0000-000000000000"), 2 },
                    { new Guid("32b1f5a9-9db1-42c2-a485-8e72362eb75d"), 383, 508, null, 26, "Tasty Cotton Bike", "Stephany", 617, 6, new Guid("00000000-0000-0000-0000-000000000000"), 201 },
                    { new Guid("3394dfa5-cdea-4e4c-8f52-ec69909d26b6"), 17, 218, null, 547, "Gorgeous Plastic Keyboard", "Quentin", 568, 621, new Guid("00000000-0000-0000-0000-000000000000"), 114 },
                    { new Guid("35ac1ae0-5489-47c4-afea-f4a6e591c8d1"), 658, 85, null, 22, "Incredible Wooden Fish", "Jude", 351, 218, new Guid("00000000-0000-0000-0000-000000000000"), 661 },
                    { new Guid("38a15a2d-f39b-4c82-8da1-af43e4325356"), 131, 186, null, 503, "Practical Frozen Keyboard", "Hester", 321, 426, new Guid("00000000-0000-0000-0000-000000000000"), 682 },
                    { new Guid("39c7ca0b-0341-44be-b166-ebcdcadab23a"), 523, 503, null, 22, "Ergonomic Fresh Car", "Julianne", 555, 154, new Guid("00000000-0000-0000-0000-000000000000"), 189 },
                    { new Guid("3dd4fcb1-8b16-491c-ac6a-e20687779964"), 562, 475, null, 586, "Generic Frozen Mouse", "Myrna", 233, 456, new Guid("00000000-0000-0000-0000-000000000000"), 354 },
                    { new Guid("3eed2cb2-f011-4b51-aadf-5d220fc29776"), 585, 214, null, 178, "Ergonomic Fresh Car", "Eldridge", 126, 527, new Guid("00000000-0000-0000-0000-000000000000"), 151 },
                    { new Guid("4248f718-5db1-48f3-9390-fc8bb64aa972"), 335, 423, null, 595, "Generic Cotton Bike", "Lorenzo", 284, 75, new Guid("00000000-0000-0000-0000-000000000000"), 529 },
                    { new Guid("44c8199e-da3a-4ee0-9db3-ebe4d4ba4e56"), 487, 74, null, 92, "Rustic Soft Cheese", "Darron", 349, 232, new Guid("00000000-0000-0000-0000-000000000000"), 434 },
                    { new Guid("45336c6e-8524-49ca-9612-14353fb60b15"), 457, 561, null, 494, "Fantastic Wooden Sausages", "Edison", 46, 554, new Guid("00000000-0000-0000-0000-000000000000"), 169 },
                    { new Guid("45d62ae3-e516-4c58-bb9c-a1b574a6d259"), 433, 473, null, 647, "Intelligent Rubber Mouse", "Prudence", 282, 475, new Guid("00000000-0000-0000-0000-000000000000"), 287 },
                    { new Guid("46f889f2-1de2-480d-b09d-3a7a8b40415a"), 663, 448, null, 533, "Tasty Plastic Computer", "Simeon", 131, 42, new Guid("00000000-0000-0000-0000-000000000000"), 407 },
                    { new Guid("5a2c91d5-ad00-4916-bec8-c3e6537e60ea"), 255, 570, null, 382, "Rustic Metal Gloves", "Gerda", 13, 101, new Guid("00000000-0000-0000-0000-000000000000"), 196 },
                    { new Guid("5cfbe299-657c-46a7-8255-93a5c9f379d0"), 425, 408, null, 225, "Refined Frozen Shirt", "Pierre", 352, 206, new Guid("00000000-0000-0000-0000-000000000000"), 222 },
                    { new Guid("5f3cce4f-c51f-43fe-8963-5af7c8dab361"), 150, 624, null, 146, "Rustic Frozen Salad", "Prudence", 72, 203, new Guid("00000000-0000-0000-0000-000000000000"), 633 },
                    { new Guid("5ff2a1aa-d576-4144-8ee2-256570c2e797"), 167, 380, null, 203, "Generic Granite Chips", "Evangeline", 266, 8, new Guid("00000000-0000-0000-0000-000000000000"), 245 },
                    { new Guid("627e639f-e18c-42a0-9e6e-f95c34766795"), 486, 596, null, 431, "Licensed Rubber Table", "Samara", 33, 460, new Guid("00000000-0000-0000-0000-000000000000"), 424 },
                    { new Guid("64032793-92da-471b-8fef-3d0a0ab4d6ae"), 557, 90, null, 384, "Small Concrete Fish", "Alene", 195, 186, new Guid("00000000-0000-0000-0000-000000000000"), 324 },
                    { new Guid("6634dc37-11b4-4039-a0cb-14a4bf011254"), 375, 489, null, 496, "Licensed Fresh Mouse", "Emory", 328, 374, new Guid("00000000-0000-0000-0000-000000000000"), 689 },
                    { new Guid("68e227d3-4a62-4913-b377-174eb75a857a"), 441, 631, null, 684, "Awesome Concrete Chair", "Elwyn", 621, 343, new Guid("00000000-0000-0000-0000-000000000000"), 714 },
                    { new Guid("6e16706a-323b-4c93-bae5-f112b0d0687f"), 241, 639, null, 441, "Refined Granite Car", "Neha", 473, 17, new Guid("00000000-0000-0000-0000-000000000000"), 555 },
                    { new Guid("7026e0f7-7784-47e6-ba52-a8202a8f04a5"), 84, 471, null, 253, "Refined Metal Table", "Sabrina", 24, 564, new Guid("00000000-0000-0000-0000-000000000000"), 813 },
                    { new Guid("7032e29d-70c6-455a-91c9-0295d0e7b28e"), 367, 501, null, 490, "Gorgeous Granite Keyboard", "Odell", 473, 554, new Guid("00000000-0000-0000-0000-000000000000"), 669 },
                    { new Guid("706dd914-e0a9-4aa6-8c98-16ece935cdd1"), 133, 239, null, 149, "Unbranded Frozen Gloves", "Clara", 294, 488, new Guid("00000000-0000-0000-0000-000000000000"), 120 },
                    { new Guid("74d1aa89-d813-4640-908a-6ef5e6fbfcab"), 631, 403, null, 290, "Refined Concrete Computer", "Lonzo", 414, 319, new Guid("00000000-0000-0000-0000-000000000000"), 310 },
                    { new Guid("79fab976-49e5-44e3-ae04-d118167fb143"), 143, 640, null, 445, "Sleek Fresh Cheese", "Demarcus", 282, 177, new Guid("00000000-0000-0000-0000-000000000000"), 10 },
                    { new Guid("7a8b4188-503a-493e-a147-1b3159c6d650"), 157, 322, null, 621, "Gorgeous Fresh Hat", "Dave", 341, 564, new Guid("00000000-0000-0000-0000-000000000000"), 78 },
                    { new Guid("7f4553f2-8020-472d-9379-48b1dc647df3"), 511, 302, null, 23, "Rustic Fresh Salad", "Jedediah", 326, 253, new Guid("00000000-0000-0000-0000-000000000000"), 356 },
                    { new Guid("897e5f82-d9d3-4450-890b-b2ee4b5f312a"), 517, 485, null, 468, "Practical Wooden Salad", "Layla", 457, 535, new Guid("00000000-0000-0000-0000-000000000000"), 558 },
                    { new Guid("95242b39-4e00-4079-b5f2-7c4a598ce33c"), 395, 117, null, 570, "Rustic Wooden Chips", "Luella", 174, 67, new Guid("00000000-0000-0000-0000-000000000000"), 162 },
                    { new Guid("95d08833-3a41-4182-9714-d80f9e31eae3"), 631, 355, null, 201, "Small Fresh Chips", "Glen", 337, 188, new Guid("00000000-0000-0000-0000-000000000000"), 741 },
                    { new Guid("9cd4e581-c513-4775-b3c2-f9b72532bd3f"), 104, 161, null, 101, "Awesome Rubber Shirt", "Jacynthe", 358, 45, new Guid("00000000-0000-0000-0000-000000000000"), 719 },
                    { new Guid("a041c6e1-61ee-45aa-b444-a60b105f53e2"), 402, 641, null, 165, "Intelligent Concrete Chips", "Griffin", 347, 403, new Guid("00000000-0000-0000-0000-000000000000"), 501 },
                    { new Guid("a48cc454-cb8c-419e-a9f9-fd4e84b6458b"), 691, 199, null, 568, "Handmade Rubber Shirt", "Unique", 258, 190, new Guid("00000000-0000-0000-0000-000000000000"), 602 },
                    { new Guid("a4f29555-3f29-4dd6-a708-a0a02ba72c59"), 676, 373, null, 639, "Gorgeous Fresh Bike", "Kelli", 424, 465, new Guid("00000000-0000-0000-0000-000000000000"), 397 },
                    { new Guid("a80853de-8577-4ef2-a354-9b554f918afd"), 680, 218, null, 337, "Small Frozen Fish", "Consuelo", 429, 507, new Guid("00000000-0000-0000-0000-000000000000"), 233 },
                    { new Guid("a895728f-ef73-436d-a83d-ab7215d161ae"), 528, 292, null, 374, "Practical Fresh Tuna", "Alfreda", 282, 51, new Guid("00000000-0000-0000-0000-000000000000"), 97 },
                    { new Guid("aa8f9e61-861f-4ec9-93da-3754edd117b2"), 101, 191, null, 542, "Gorgeous Wooden Table", "Bryana", 1, 424, new Guid("00000000-0000-0000-0000-000000000000"), 45 },
                    { new Guid("af866876-a6d5-4e01-b981-a5174b0b144b"), 457, 571, null, 34, "Intelligent Frozen Chips", "Foster", 13, 156, new Guid("00000000-0000-0000-0000-000000000000"), 150 },
                    { new Guid("b4a9a8cc-d727-45d5-833b-393b65706532"), 445, 438, null, 242, "Incredible Soft Pants", "Bonnie", 431, 109, new Guid("00000000-0000-0000-0000-000000000000"), 651 },
                    { new Guid("b6363fc3-3b81-4966-99a3-7183caf46578"), 568, 379, null, 100, "Unbranded Fresh Tuna", "Keshaun", 338, 537, new Guid("00000000-0000-0000-0000-000000000000"), 89 },
                    { new Guid("b7742c0a-02eb-402c-9724-74a8c2adae29"), 36, 118, null, 35, "Handmade Soft Towels", "Raphaelle", 83, 250, new Guid("00000000-0000-0000-0000-000000000000"), 697 },
                    { new Guid("b9a433ee-0947-4a77-9c3f-f48d9fa7d4e5"), 507, 424, null, 525, "Awesome Rubber Sausages", "Jayden", 34, 379, new Guid("00000000-0000-0000-0000-000000000000"), 492 },
                    { new Guid("bb1abeae-2017-445d-9f75-134d1be5f7aa"), 604, 411, null, 619, "Generic Rubber Hat", "Uriel", 286, 410, new Guid("00000000-0000-0000-0000-000000000000"), 556 },
                    { new Guid("be4b1170-e314-463c-afc3-700e2adc85a1"), 141, 106, null, 379, "Licensed Granite Bacon", "Alexie", 40, 495, new Guid("00000000-0000-0000-0000-000000000000"), 390 },
                    { new Guid("c170a504-540d-4ed7-b93d-a632a8b0d1e1"), 162, 104, null, 539, "Sleek Fresh Computer", "Erica", 507, 204, new Guid("00000000-0000-0000-0000-000000000000"), 685 },
                    { new Guid("c4b95468-3646-424f-9ed4-f62791bcaa86"), 387, 442, null, 481, "Tasty Concrete Salad", "Westley", 483, 28, new Guid("00000000-0000-0000-0000-000000000000"), 372 },
                    { new Guid("ce3c5df8-ad75-4565-acc8-12a41e0e8b56"), 284, 95, null, 103, "Tasty Rubber Keyboard", "Lilliana", 570, 455, new Guid("00000000-0000-0000-0000-000000000000"), 412 },
                    { new Guid("d09ea5bf-1e86-4039-9c22-ad3f75998964"), 689, 215, null, 227, "Handmade Frozen Gloves", "Silas", 285, 250, new Guid("00000000-0000-0000-0000-000000000000"), 387 },
                    { new Guid("d0c283e2-dd10-46f3-93b8-8caaf0d46871"), 284, 578, null, 451, "Awesome Rubber Table", "Meredith", 609, 415, new Guid("00000000-0000-0000-0000-000000000000"), 680 },
                    { new Guid("d248de2f-2363-4241-a4b7-8c390c72c3d1"), 612, 405, null, 214, "Handmade Frozen Chips", "Cleo", 499, 200, new Guid("00000000-0000-0000-0000-000000000000"), 180 },
                    { new Guid("d2a343e4-d6d5-44d4-9a05-772eb12d11bc"), 489, 411, null, 391, "Handcrafted Frozen Bacon", "Bernice", 558, 87, new Guid("00000000-0000-0000-0000-000000000000"), 449 },
                    { new Guid("d56ab89b-f0a4-4edf-99d7-3f56c029e8a5"), 181, 399, null, 492, "Generic Wooden Shoes", "Elsa", 257, 319, new Guid("00000000-0000-0000-0000-000000000000"), 558 },
                    { new Guid("d5ab21ce-59d5-4419-99d3-f13f4a310af1"), 557, 188, null, 5, "Awesome Metal Shirt", "Elisha", 100, 127, new Guid("00000000-0000-0000-0000-000000000000"), 814 },
                    { new Guid("d5c07087-dedf-4e34-92f7-b49f3ca5106e"), 128, 410, null, 385, "Ergonomic Cotton Gloves", "Kristy", 162, 442, new Guid("00000000-0000-0000-0000-000000000000"), 284 },
                    { new Guid("d8004d44-9783-44f5-b1ba-3b6a4fffa427"), 220, 160, null, 94, "Unbranded Plastic Mouse", "Jody", 92, 279, new Guid("00000000-0000-0000-0000-000000000000"), 364 },
                    { new Guid("d980f17a-7a1f-4da1-b331-12bd7562c264"), 97, 10, null, 654, "Licensed Frozen Mouse", "Reva", 203, 462, new Guid("00000000-0000-0000-0000-000000000000"), 347 },
                    { new Guid("da31906a-61cf-4c83-af6f-f67934c0ded6"), 246, 282, null, 322, "Practical Frozen Shoes", "Jan", 223, 630, new Guid("00000000-0000-0000-0000-000000000000"), 676 },
                    { new Guid("db163d11-8e55-4f88-92b7-011c9843dea0"), 426, 460, null, 17, "Refined Granite Salad", "Hertha", 245, 436, new Guid("00000000-0000-0000-0000-000000000000"), 202 },
                    { new Guid("dd938f44-1084-4949-af6a-90e9823a84ea"), 86, 85, null, 150, "Generic Frozen Towels", "Evalyn", 198, 200, new Guid("00000000-0000-0000-0000-000000000000"), 158 },
                    { new Guid("dee9e3e5-aa3c-4c94-ae89-97bfb1994ce0"), 491, 143, null, 252, "Awesome Wooden Mouse", "Esperanza", 177, 404, new Guid("00000000-0000-0000-0000-000000000000"), 810 },
                    { new Guid("defca90e-db78-4a62-93b0-95a3a6b35133"), 384, 421, null, 316, "Unbranded Steel Pizza", "Emanuel", 14, 85, new Guid("00000000-0000-0000-0000-000000000000"), 709 },
                    { new Guid("e0f84018-0b4c-4313-9e9b-82b94af0261b"), 253, 325, null, 67, "Ergonomic Wooden Car", "Franz", 307, 52, new Guid("00000000-0000-0000-0000-000000000000"), 681 },
                    { new Guid("e27c7c13-6a26-40d3-9b1a-9fd2398b4185"), 77, 115, null, 399, "Handmade Fresh Car", "Adolfo", 593, 542, new Guid("00000000-0000-0000-0000-000000000000"), 362 },
                    { new Guid("e3ae5684-09c1-47bb-b55d-1124cd5543c5"), 345, 588, null, 242, "Licensed Plastic Computer", "Casey", 486, 460, new Guid("00000000-0000-0000-0000-000000000000"), 96 },
                    { new Guid("e3b13c49-f9b8-4ae7-b1a7-b0f54a3d6168"), 305, 484, null, 357, "Licensed Granite Bacon", "Preston", 23, 575, new Guid("00000000-0000-0000-0000-000000000000"), 278 },
                    { new Guid("f22f0caa-28e6-4bfd-8942-66eb85e176bc"), 364, 632, null, 287, "Small Fresh Pizza", "Katelynn", 22, 117, new Guid("00000000-0000-0000-0000-000000000000"), 517 },
                    { new Guid("f80375a1-a185-4dc7-8ef2-62109d645444"), 692, 569, null, 346, "Handmade Metal Keyboard", "Eldora", 457, 201, new Guid("00000000-0000-0000-0000-000000000000"), 422 },
                    { new Guid("fae791c9-5fad-4469-8203-668b06187868"), 212, 309, null, 308, "Handmade Steel Computer", "Cyril", 387, 584, new Guid("00000000-0000-0000-0000-000000000000"), 593 },
                    { new Guid("fb81b826-cc2b-499d-a292-702fb3dc8820"), 19, 215, null, 698, "Incredible Granite Sausages", "Abigayle", 324, 341, new Guid("00000000-0000-0000-0000-000000000000"), 567 },
                    { new Guid("fcbc29e1-2e26-4536-a123-1857114a30b5"), 52, 160, null, 153, "Ergonomic Granite Bike", "Johnson", 587, 383, new Guid("00000000-0000-0000-0000-000000000000"), 317 },
                    { new Guid("ffc7e58c-ce2f-43ee-8622-fd0bc28f7dbe"), 402, 167, null, 40, "Generic Cotton Chips", "Sophia", 457, 627, new Guid("00000000-0000-0000-0000-000000000000"), 567 }
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
