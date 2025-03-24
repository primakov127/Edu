using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(1024)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(1024)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(16,3)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1024)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "ParentId", "Type" },
                values: new object[,]
                {
                    { new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Food", null, 0 },
                    { new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), "Transportation", null, 0 },
                    { new Guid("ec65c208-2729-c1e9-d523-a898c5b77652"), "Salary", null, 1 },
                    { new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Bonus", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Hash", "Name", "Salt" },
                values: new object[,]
                {
                    { new Guid("41874e01-577f-d190-db92-f2ff084447b1"), "Trace74@gmail.com", "740dc633abe3a04ffc4da211cf750bcc33ee55c00a822faff73225152e0cfd2ee20626a904df9ffc47587a9d18c65f02893ff4c9da2e81b2f3778974924993403a70bfd0acbd8b40d97178ae2e6cf2fa51adaa7f67dce9cdd4c0c28a08dc9017c186065227b0bd0928ea6fd280d2da6555fd15d6f9d577f284a1261d35d0925806b6e28ca7bc18b00aa8f52f32ab8ddc4540c845ce6ab4ca9cff8d8b3b2c8c4dae8b3b4855b1e83e5f2bdd47d9d058c098fcc06e869316ca8469a9fca1dae32d8b86962583264067c2812350922b2c053ba5e61110066889a6dbb1b567c7472c3c28619616012e90980ce4a205e699dad4395f39d7a41927dcdb66ee208022d7953ebfaa56e6a517378cc2375575737aa3ab53ce235f874ce0caa0a71c858422f4c7b51faaa9c4ee0a666c0983a9a65d03f3bd19fc0061adda4edbb342f7b7544c884b338d69cf368db017f47cf8eae77bba818271505264f8eec42cc417ba5efe1048d748902ff55b85c0b39fd4007cb71606f6a793b2ad4b2f2f1e3e75b9641d4ad95fb1b568874004e79c5221fab1052ddffa62314c8b600b8169385a640069415a9505eb3878a7beaf8ee8a4a54222ab865c6bb32b5a1c0e8166052df4ab0c81dc042e8f45b3303d4591c4a237c20f2624c5bbca961b9eaf0d6b36481e0a25f4251e3e199f853e84dd12972b033da1737c94dbb2bd14ee525cd44cba25e0", "Elvie48", "4e874e654622f7c5ec1e18e42fa1e18db77f9dafec05b255e448c29bf4453563e4770dc022f478909529cf08ebf484b96d76bd41735a2536b3be2c7e4e94d78e66ea125c0128966888958d69582c303fb73b6848efd0ae5d80b5e25905490880e2c22a2f416905e734434e182ab13a766c1822adec0ccb8a6d6c35b00308e0c9a03345509748d4c611a54a20118e22fe072b7561862c133b796c565fe322c6e7768620ecb8cd75fddd78c28913d433528b5abd96ba1c9778445ff5a5ee4e3a883a5c042030d21b0ac40fe6221fcc8a21189e2b8f14be8833ea1f99ad82a08689dc181171b1d9a4a8c9de8377eb6f076bc20c7a1c2038c024824f8a0a49a6b713a1d83d1181b80ebd927d3732167d0a1affea3a0a0377e795edd80302eb6c631df08100ae1dd00c39d2f3d8acebc7334c2a7ef74e2e7360227cf44ef65c2532bd90e645a5d10f176e8a064f83a1825fa029951cd22a63d05e63d925998ab3d8fe60c7d0dbcd49846ab9b110dd00d70a49a8dd3d0661d41f034173cec52f7c25a19af" },
                    { new Guid("b4877cb9-87df-1f5b-f773-85d44b14472a"), "Dell.Muller@yahoo.com", "7f5fff7bebc38dcbc8166b49de6c9a7419b4ae27d6adb9c233bb80ecbc219b14481f280d598006d31486ecc1ae8dc1e145937dfb2e5e7ec4fef43a67c044f213b7bbdac45c4f6dac24ed2aeae1668acfd23f30652be7661e682b431190cc35ba0423aa81d9b6b648f80f80b902623a1cf4614d4b00ea8a52c4da4b20993836d37e77023135f72006c45fc773168aac793b393e2a0b7fcbd88dbf0e606359a967d546d62d1be008768f1d0794422088f75f1677a2add4f50ebf1a7976cf1b3259b7b061e15f22945f244975fb7b975fe884889f790f5865c7a29fdb26709b86c51a95bc52cb870752f1d26fac22196b193f7cb7cdc6223a6fb6c799f10c29bcc1ae400867506fc798b2effa0af5cf4220a18565e2041830583ae9dc10d90bc733d54bf3253cfb877ef3ba493ef87c43591ebdca9f7850d67522b9b8e416b6c60f7699c925ac2b320901927bd8f6b5e2217597cd88f6ee630f515acd8b81a6dc68903d89d38031df1c6cfdc85adefa32b2f646f36c422ba6d90d01c9c1a90a92f55127abc253895a0606a52955a3b62b313c5846e41db902b099a3792cbcd7060a076947297545eb577ad91f9999d7974ad199b2c160b14def75059680dc0b9a001a8c2bb5eb30375cbd037e1689bf107b0b0a41db9b7e38c5740cac9282480c3d37087a7904ac733fc68d0b132d12c4bd79bb74ecc6c52da5e4c935d76d5995db", "Raquel.Harvey91", "d4e88888c19fb153b388192b35ae42691c58bd6c317338bb05d152831343d939b0efcc7edb4f1f7b9eee544e317883eaee83abf3ee39d822b99fa436bfba5e5ada12630eeb061b1be5df9f09b28a04ef99c370b78b0f4c50e0cf160da774b5dac0d7fd4e956ef05ec8c08ed38e9f86c2d623ed10cd6cf1e928739d1e3af044539318e1ff6b4a8146ffc0e99f4304e0c7833b06a088cd97616814844fa14a1b16fd15e8695b86cb6ddee5e7e3e30e10fd66ec502d18fccd3eb7c2cb77ee6b8875cbf6d97db1468261013a3c0be6e7a7591af1ec11ff7b71fc74a65c10a487b023ba4e253301b3454c62f5cf448e79495ed3fcc19217531eb40b090c7c6063d9f6bc6167058d45903a32999cd0c25ca5488f747ae8bb038135cc0af5dfe55313a28cc99e2941ddba8aeffe598227614a670eab49cd976e7f44db513bdf4a71704aa6ddfc54315d39a2224954340b7a2b582b41174050e16fbaf4e5cb5528c34b28cdb7590bd34461e" },
                    { new Guid("95851a0b-4379-2c6f-2a8c-21c28964763e"), "Kenyatta_Mohr48@gmail.com", "01ecc3a1d9f44f7fd922e3c6c71f21d41dca87e5e03bf8bf54bf878c58f41bfccb363d65bc4e0074b19e5dc94f40893317f455c8e64b3ab51b90116fe91385d180c912e5410e805a4ffd0320006c49f88223d14ec3bf086d36e96015ec90c21b1865e2c2b00d72f8988da6181d41832910e810f09cd5f3dcd173930b6e41eba8e7b74668873e8c8df836befef223ce2e25788686bea20229561573cf7d7132ca55b25f49fdbc4ded08d5cd6e981be72820da6f45185a7fb9fa0a46e7ec9de9b8a3a3036048337c79c7c3673c15b95778ddf4578b406c2a025006d722fe2b7cac0b59c245f0f61697484570b6bc475d3759c74662ca7c8b194a7f855f0fefdc01d807a22d219c9fefbb2a64e04c64774f95e0bae189c7b8611f42a6b9902ebd5bca330e40d01c764c65383253956a706a41b15203b3594f12b685ad89509a799ca685b3635fcfdcea33f1800691c486c2a8ed7c67f40a08b91f63974961b971af3a55d037c81305616239f88235750dfd917626b0cf616090ba34e10b13189d6f849fdfff72df16c3c6a69ae81c4e437f87917a2bb4dc409b7eb2206d50d1b0a3bd69dab23fa5c240297674c81bc6c10b9a06afdd29f35112cde194b61e81d552ffb12e63b93d5920aa9e2e15fa4b6b0c4c465f0e7b6f0d18c872c6f0d6279acf97985cabab7772418cfe4d0dd38ec84cf6593820eb80f78b10ecbebc6cb13be2", "Waldo_Stanton83", "b81dbe09ff85fd5adcb9810b927c1c2c6a3f7e62e2be277e676e38e975497382dbf5a53f68b55291b86a539db9719dbaa9067240378ad944c2eedec92190d159d0ac1298356ebef25247fdcbc74694222fdde83a85a88ee316abdd903f0ae3ff23bc124dfaf9243d804297545d9f78b45b54221e1db2efdeb21dfc5ae7649556eb46fea6f51cc265fa347e596a5bbd5c7433b7fc8ae9b8eb014f10f05b049fb10457f398a7cc0bddbab986b653d07a39fc9737cc8c4a420ad29f318a9e1c681f33d31694de1c10232234145d3fe5506fb4604d8784150c88be935cefe0f284fc811da1e5abcd20c7659672ae6724d5f344cfbbea039900ce37c2b8556262f974c88d3ccb7f6381e6a4159c8cf7884bb6c5c87eb6b0ac22d5408a81aff" },
                    { new Guid("d9ef8592-92ac-3a6b-f3c0-e5bb2be30c1d"), "Jade.Deckow24@yahoo.com", "7102516f027f58fc288450e092f176449fbf1da03419176acd4a5fe73f822479e366cfb4d701e4f2b45929e904b157eec8bd10ec2fdefd8f066dfd755c5839f59145811b6872c0a3bc1e00fe1684a588074d836f5a76648512d7805926428c100e25bda85195888cd327810f2ba2e468966723a484266f09e7459a8fd32f2791a1c110a99de3fa83b047f1ffe79f0a20b0b52f8ddbcbb4f3af3132192d2a6b8ebd7ee20c86a45339764171d9e235ce712d0dc147f78d8d4e9920677a0efcfb0af82736c61c1f8011e4b3b6ba66de28837defbdb3cce95710ddeafde8d70c9e394d7a1151976f714f4c049e3af523cead8558f6ec7d186f0c318ceff69dbcf14ad962bcfde4ccdb4f560b6ef95fe2b2d686ad8d061ada228d9c78183f9dcbec2c663617675a9c0573609ea44f3b3b1485713be2c15037f6e4595e331213353a50145f1b44379a1d0cde68fa23f1aae7daa25a1f3a40aba61337854d0721f0195c9e0e85aebb3ef688f677e86c2d8ff28bbe1c63bdcaa8a18b860b2dd183bbcae828305c2caaa4dd204d682d8d00427001b262e86c4308293a1b6f4565f5f48f5a998b7f2c7a4ed0a7c91b91d5c1388135e5e918319979177ea87fe908b2f6c9457e0721545f20943494df936446df8d5f52127fc9339f70f7eac7b4c38b3b36c892a721d984c6a7d4660e1d415eacc05c7154685dd2f77590de4d5d6ce91360d7", "Kirstin.Kirlin70", "0f829ee130eec9f59edb869a96c616c578760e405c2d8d1f1ec2fc696d83180c3973294bac5b4b2b4c42aa5a2df251fdc59e6dd8a1726a5abde43d293c149158d7fe1356fc79234785782aae30b9c8f8bf4ea6877857686f8ac4ad63d1b17ba6dee3e5d1cf09537aab12baed8118b70cee97a213da8adcdaa07ca8b2f0bc3464f4b690f7ae50240b37eb0325377a74f843b816090f2b3a0bff9c5b3b253285f5fcce97ac64a016297ca7b2390f6b3e1b0cc7d1275c60029b3abca7ac82e90f973f059bb5a22eb29d5a7835081feb38753fd01428f5175c169045714df849df22bcbc58b18f8d3935e72231e1af1808af3fb8041042d886a55ea5d0eae915731f49a3da4961d035935b31e52310972b911e3fc68aa1fb2d78fe0bf01f672c1d6a8cf52a7e387c66039074bd21c4854b9ca426e1656186848f6e3061fa9d8d12a7fa214a5791e95b88b9e5885857c09933607e16bb8b64355e401834f649cce4e0ea343a65d2dd115f2dc87a0210979fd3c65820ba9cb171534d908584a0321ebe590bbcd222eaffafb53c5cb6d1e1c88b1dbe1a78f6e66e4b637bbe89d9d9dc5a93923ce1eaded4ffd3b90d034107ceb313c3427955d019b89dca0c9c36d1c65ff9d97caab13a0f1a67de1024a00e56de0d17c10d32fe8eb342b496ee68f7bc5545" },
                    { new Guid("202ecdfc-1c7c-a65c-9cae-ba26525d0fbf"), "Hattie.Zieme60@hotmail.com", "cf05e6d724a0e345b1822b6c594d68245230349564bf87b426be627083f51f1a26bbf32773cdf64ed0bfd3d2a27f443631d2cf4e43635a12f17131ce881cc223f5ae922ebdb9dad015f3c1314e94e721123ff39de956631ea0b63f7e299a8e04ba8a6d1eb243cca1cb9dcbe1b5d69e4f81bca67cecb0a425e8ed528fb6f10a5dd5aa1e654cef0d77378007a68b0475c47d35973f289839fee7e924d6a416e1ee0a7292dc38d7e12fc25f72120da55d10aa881c4c9269758912abce7d942c88757cd399dfd855c7ba5032354c3afda731b02a84084ae381018777542181fea05554ac51200ae97131ae42fcb6d12642e348e374c7477a5996dd4bb26993e3ebbdca4f3fa52de840147b96e28125a35888b9db4a3d3e9e4d4829c225fa22cd560945da250c8b3099c4011bc666a391d58cefaf0a5c9fa71f1968d344dee7ffcee22619ed45c42cbf4b20b575791c18a60a074bd7a93770202f34dc39ade772cbb647c3a8da5210e770a1558377c6d5f8d7c1bb4e4a73707af6067a65d1f574b7ad5a4dcccbcae5c6f26658021639bf70ff89bd62a3acec675854d421c38d920c3bbfd2b1b4c2e3450c43a23ad6d849972e8207a2d3888038e3dcdd21802653d2a4ffb24822669a2d3490bc94b79053da66e303dcf4ab7c7de4219c6dba33833e4bf3cecf6d172ecffb100c0af085fa4b0b6bc41f73acafbdd33c12e8b54c67fc85", "Iva.Medhurst", "7713ba28d14ff4b7b689dde07f5903e35845c081fa066547a0350b9980cc488a30a705abe6a3c791aef0f939eacc4bd71636bc65587915c16a1698aac1868e729226436d7aa71a79db59a6e9b99a40c7140f36c343efd3829f8c9e8248aaab96d36da857e2477fb817058fe2cdaab289981ada7091e690a5d293a4ee530ddbbc9bdfd0b6f0b7179b25d985e5925aaa2e51de3b7c624a87dea5a8d134d86ab1c4dd109a87d12513c156f50a03d91a4d056fdb5d4fc3bcee29c4551743dd209d200df160c82f8ce35f67e07b4fb9d8a46f1ac1e13b8d21f7498391f185905c23de99b37405428a82044406a5ff268eb684f485c02424cc9dc6017e36439b10b2aea3b4aa841c468364a1dae91804c1f2809e1528c593d72db54d6a4f002246e74f33ca1112580aca629" },
                    { new Guid("c57843f2-ce85-38c9-3d79-4b32b9be873b"), "Nikolas.OConnell96@yahoo.com", "423a56b095141450cbe87344cc507f49004f6c313af69005a7ffef80efd81a9a1740f5a07c4c4dacc06ff4a18416eb091451cf54df72bbb151b149acc27b441ccbbf890da12fd86d801dff47a8597a09ea5f0c8b0d627af3ca3424cd635f375f181226cb75c1820f91cc7c6ae89d7979760e9c06e7cd7b432562a985274acf4ed291126c05eff82236a135eedbb186af2e041310e925b869416642a84b366439bfd08e104939293542d704af3706fba958abb606f51af15b7e137c964dc1db09fa3ae79e167a2f0225e19619e37d9f8458b5eacf43204f44dae8cf0889bb0b42d3494b479ec5404fe30f107583c4f0f9ef21aa0156fd3a374cccb51dbf11e088f274d3543e9a192ef5f332e9e55b9e35e6e02e91689cb6b2d219054c4e68eaa4b3bab1b1bdcb81d893d6d95911b4812ce517a06b7fd289331eebc461e299678abfc305d9c2fdc207d83a3709ff987c4f6279c02b05e9485c11be4e73e231c41fef69a7bc579e9756ac6606b8b4aad1fc3ea51b2a6e8d4996dc6febe74ee5c0f47daacf5eab02dd31a3c0a0d8f203dcd5e457ee9e7842bc96aca94f9702bae20eea398c2b9e82bac28a81140fae7c3ff5754090ed9ff677b558149fd9a3f9568ae2b55c88cb825973317beac88b6504826574b5f8f88e6a40cc64edb463da638735b0127e1eb62e1d7594e339a3e8752cf0b1f4ea472014171f30938f126d3e6c", "Eden_Braun", "e6130e36ff613752778112c8bfde1661642d04100aa32eea0bc7daaba970155895ae48125717895d02d59e3c9637c0fb419c3f58a91683313afe70ea1e4d4a548626f891c5b0dd36323200342fb4a7303de21c1a0e124ed4bea263372d40d4651bc0e0560922e103169cd190960381cb7c092d5a832d0180d0e7ba7f1b7801dec7a216140f39fc07ef6835fc40876d96630966f7ea6b7e05bf90b5a67ed0dad25c3bb6080fa9f45603c649b08a288e94c36ab494f10bb173870ae7ec022147f165dbdaab977290572e01ee645aa918f71e554c5ec4160b20cbe57d37e86301a07f0ba0269159d04979c599f3ad6c52daa0e0b75c98c589ae3db6547d0c0d96063afd14ef30c0d9b138887656800e7823862d9ddffb3576061ea1d7fc59403f7ad9867d75b89b3fe2f9c8e15175808cbf487edae47464d495a11a3ecb47f256ceda7a8045a81ab033b267b1c5cc96acf07773ded9dbfbd1f34c62f53bd1eb6dae80249f5d4d9f218ac62e5c013c5b012f102ceba469e2c48c93f0bb8c010c9ac2aae2ebc1cd8ced5f391d224575cdadbbcb8156dd7d4e3cd2b1809ff759a9fe6e1cf" },
                    { new Guid("2fc8227e-43ff-1a34-37f0-c44665bda6af"), "Bruce_Mills@yahoo.com", "307c3d39c9c5ca3708ae0cd06d0382bf0ce6dba42c04b4d4a599f7d73656df09ec50bca4e6b3b852fb928109f7375363b66eed9da4b9b9ba13715e1ccc0483faf88426312c7466d6b852c5dc5a22d44750a2068a05f96c56e980dcd9bcf8404d70e5ca640a2763584b43c4983074706f1126e0a434f2a6386638c012652b31cf42641fa410f746ecdfe1ce20ff08df1270e70e76cf7c19ef75d33b35f651f162fd0486ce875d76f500171decd87a957a94d399709ebc66e96f0e0e11f47fe253fa328bc690e21257ae3a49aa3b45272798cb2b0b295f0efce05ffbe6f9ed7641d7996a5ed77a4aa5b772227d95b8d34b53185663b6274425f91ff2fbfbf0ec1a3b5091f5136b0095369324c34699665e5838f2bd9cebb3be2ad73d7ff1c386ead767d061bb966071aa7c8eb7049d5853d3d3c3113cc7419eab8ee12fce7979b265822447858c143eba3a065b1e7db8aa090e96c5605895e7b8dc502f0c14c6bfbdb74454ed3f1c2bf023ae5f70ec479f55dba63629d8d2e3964c485d8b03680633abe719cb010c252a3e2dbc002e6f09964982524bf973cb8b1b51468dad423da68989cf5197d24d465be4472d0a77d282e1a23fe1647c969d9dc7e6217b927d37fb332136dddff6491adf5037f9b86b9900dd25b8a6a182116f1df41e7b486b0134ef866be55f52fc8a169c9cee56122e58d3328f86eaf285c70ba987b20900", "Lenny_OReilly83", "c369d4b8511e3decc60aa164b06811fe8c1798b00faa8b59c543f5fbc1ecd3642256b633b0aa6cc0bcbcdbf2d6b7ae2c86755ee5108fb4405d117a663385bb9ced2046ace5ad3f781a2cc15d002269956b1e14be35220833bf309dfc85f34765b477e87cf487f2d7de6659c9c46c479bfd6c1b53861547d588561ff27eba2a87ad81c05293df7744614c13afd443fa1ee9b7fb9733de20a097315b573947c22e2f0ecd5a7d9e5cdd94a86f82333671b00fb2fc4b19982716b6e879726ea89f3628d60aecfe6d60fc2da0229779c02b12626a9a6082893ab6ed5c424fe6e7eda4c474a4276980af4dd51465e3e6b3bf2a74ce27c9bd6a934e2198c5d753538ec67e8635b69798f3aa1c1a69e2649e190c1f3bbebd62f4c5829b1bd10d050ebc507c6ffff313439961c65674f0e5a5ec1adfdfe82abda9cd36ff146e82d61a4a542a5ac6244baaa530235fac3e7a27785185728999cd0b4d783070459566324acc5915e088ac" },
                    { new Guid("2dff03f5-b2a6-0754-3887-3ed21182e13f"), "Jasmin_Schneider@hotmail.com", "8aba84ec8dc0c30212bcbda47a280b5816ad60ef01825e5b3dd5190af63e16cd84e693b03bca58f85743ef785fefdfe95a900e201c25d5566b9929f8d5095c33d25bfe865411d1b0a782647ca03ae8a49e7a0977334d7ebbaffd31d9a91ead7c9c7e900000e2094c48fe9d181e0688c5c74a6d29fed22a904492e83cbfcb098749685a5756fb0f674f13fa6338f7068655e830baf1c798bb94617489235dbe6fd85a0e44474ddfabc3ec07e0d450bde0bda020ab02df0ac389180ae6a5dc8396931f598b82beae027171c6f1f36d3e2c866c8dee15fde0cb4b57c8a230f13b8a0f53739938f6722e7a879b00c488ddb5d5cfa8312b4383b1e1992005f573a1b5da81534f675e6c8897ac313c47050061fe5eb9cac92bb2e2cfa37f1c7bce3ee504e87adfbf0ae7128d8162a0c96fdd7eada636a22a87f7dfaa655dfeaebd3d2d81f1dae136eb9214b743718ddcc5adf48bed8c2fb42fe447d72b9e679240e9767a2e33cf5572f9e97483a3b957467101dc841639a26373703a9914b3f99cf673555309800f88c721042d86091448d794a3e1e4f92992b26767cb3abe5b2b5f2853e9912b48afdedeed15bd0f7fb2234260c74dd5506b0c06e3d7ecd73e195f81378d15a0fc0b65fbf44f6d493445b4f5758933589c72c21ef5a0a9a53ead144bda30c58bfc5952d136669ebea26497657b41e019de0e4100199aee2ef46af328", "Arvilla95", "019db235c8adda9253fdc79962aa69ac883063576516712ac8a02a99707979e3ee4468b1e87653150fdefa9ee986cbfd6e79cd33c81a2234e198bf34465c04529af7b882c9168fbc638a2717a34676372f182c9687b2ddc5a96dcb0188d832a56a38e39aa21abf9c6ece06a7ff09e026c6b39376fc2aa568f0146c50fc9e2fb9fbe5452275e330d997aeedff1a4da83f18bf6049dfd1d1deef5b5cb1be49058e1f2a4e28200f0e2fd5ea38a4d937cb986ffdf2a0dd84cb1cc4ba6db84ddbaab77781e4fbbed6f68277b80e2937925e6211c420d75ff8048e5b33f3695fd7bd6d7b4e93f79430fa8feacaa33ea2f336c792040a41bc9b05aa6e910c2485374c437b7ca4e45bee97e574" },
                    { new Guid("5db6ffb8-0291-d8b3-ef8b-c185e50aff60"), "Giovanny5@hotmail.com", "1ac746fc8bd65b5aed2a0ecf591ee2e9393f80bb00806182ad18e803ec2a40e5d43c851e26a06c931f3016ba8f1cd07f2222eba5c257e0d13f85dd3788483501eae396565e4f03c82f8e8224fb9571161383298c92ff8465cc53d29c894ddfe3cddda8596b4522ba539bcd9f9cb95bf93c2a79b36cd1d3a5d989637f4d3edc3bba26003b854f071615bc363043696c6a9152145c5c00f7eccdc70684711caa5bea6f1f4d0f66621c59d90f9291bf291b74241fad8f7101e40470cbbf046034b7daf10cb5f001781726ed11eb823c999430352c44811cba782eed5d5cb38d8fc56cd74c452a40f20eba9abce5b79f46b95b5ed046a9ab94c92a2d51aad7cc241beaa3c20a63f213c6b0d94d331b0548367fcea8d09772188aa502776067201b6df9a26ec32cfd611926ae71ef8b725cee0928e63c9dfa89a558eb086dbaab69d6e1cce9bc2d4a147e12cdd2e835d3c860f9c7de6cd2923cb62ba4c08b2499c7fa74a88012b0fb9c469610e23f00485cf62faf22e1a78b1d1602065fb51b87c8df099a1446706697e3ee82c90335e7a75199b7374bdaf584b9c58d0a27957c6dcfa4d0c6f7ac52aaae94a4e71f63ee0750dfa37bc6613450ceb83137133e988162644bf66d83ed4c957f2744d6e70924e5a0e0c1e4159f93e64318eee17dc76db35823e9950e6ebdca995e256c2c8e47d4a5901b8aac708f5a02ed7d1f16020a09", "Julius.Swaniawski52", "1463c8d1a36e6336ed280cd4afbb5a0bdf6bf6491cd9a1b2db2ce005729dd2b03b06d8778873e39839da73ccf03dd7ce1d6f14544b359c6380934090e37c4991c921da7f396bf732af4ce8a0350dc90a2290a46d99fbad07f5145c23f1e7993a8b9cd37597358e5559e77b5506186f30552f449cdbbe9da0c820bb3d63c72ff932f3c610f29bf7b2b0cec35" },
                    { new Guid("aa6d55e2-a80c-86b6-a6d7-dc066193588b"), "Raina_McLaughlin@gmail.com", "3068022474da2d1d8036a700480bcffb02eb11667ae3d02e8acc50ec0648277851afe5b69cf09d235221225f32bbde4f25dc63f3f5291d23302f4562babba09b7fe3f6d22f2c0ce6f78cb5bcfb0c748fc712ff4d30c4392ec5b27d02314350ae7309bc603a9a97959101857e6eeea0725dd0993ffafd369c7ea40851b12cd762374b99c0e02e6ab0526b631d8c4766274c9c1e2e2a6067a1627b1ac0573d4497db990ee7f79cc0601213f75a097aa59e0e2ad11840b90f3402b235865f8673cadbbeec2009ffbb91629897aa6c4e8a0031b53464fb1a58aa5704a306007174868fbaf4d1b58e605d2a81ab600542d5ca2b26d0a19f85a10fbafcb7bc8b9afa468ebaeef2077b215f54725ffbf5d26f1fa2cc551dadc4f0976a4a3118efb80db05800489039883acfc5cca7b904d698cc1be7083d047988443cca1e6ec6ffa36acb67c4f42eb6f108f92dc2b350b9833decdd2c7fd8833fea670009da032c95bfbe82435213f4a8f5102032d4f2ceab57c9857c621ded99083ca92ac803316785d8810ae490e53fb624bd0c41df4485ba58f00f79e6f2b6417df2ca51363069c4440b0a53d1fac256b3ca69eb3ddab7249bd7690d8c4aaa410d53d1ea5472da75ea114d012e2a44098bad1f78d2211d0e4fbf83c2d30ef4604d91094f3931bef4e4559004e70ef899c2c43edaacbf0b7e3cfae073d428850b0a591b0f6aad4143", "Elyse_Quitzon", "2a28eaba96ec515b0f55ec7b0335afc0e86ad21f9e8413185141ee25378a750aaeedbaeed6cf329d2a09aa1051759783eea244da25481210db7c57f0dd7a3946d815868ed56569e3f67efce7f956d3791da81c8639e00aa3f3ac1561aa5f0119dd38e512e0b5dd65f1798a8c69e779618422615927e0a13c3fff981257157ab5a9d8b4edce70c81551" }
                });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("52e5875f-646e-fdf3-9ec4-68da89eca8c8"), "loan", new Guid("d9ef8592-92ac-3a6b-f3c0-e5bb2be30c1d") },
                    { new Guid("1768feb4-6728-0f04-562a-134b2403471a"), "loan", new Guid("202ecdfc-1c7c-a65c-9cae-ba26525d0fbf") },
                    { new Guid("a7ffc400-307d-1168-06be-0c573b33419e"), "debit cards", new Guid("c57843f2-ce85-38c9-3d79-4b32b9be873b") },
                    { new Guid("7e106639-e6d0-0e8c-e337-caaa6a576d65"), "bank account", new Guid("c57843f2-ce85-38c9-3d79-4b32b9be873b") },
                    { new Guid("4f49d75e-a01f-a146-bf33-cc6bc3b4ccd3"), "loan", new Guid("c57843f2-ce85-38c9-3d79-4b32b9be873b") },
                    { new Guid("5bc77c97-6eb8-c7ef-dc05-3347fb010b3e"), "debit cards", new Guid("2fc8227e-43ff-1a34-37f0-c44665bda6af") },
                    { new Guid("93fff1e2-908b-4044-1ce5-5d6ce69cdf67"), "bank account", new Guid("2fc8227e-43ff-1a34-37f0-c44665bda6af") },
                    { new Guid("e71f2d91-3960-345c-1cc9-7930669412c5"), "bank account", new Guid("202ecdfc-1c7c-a65c-9cae-ba26525d0fbf") },
                    { new Guid("9b4dac38-472f-d78d-d908-6bdf363b1b35"), "loan", new Guid("2fc8227e-43ff-1a34-37f0-c44665bda6af") },
                    { new Guid("485183ec-1d45-e3a4-dac4-061921194f8e"), "bank account", new Guid("2dff03f5-b2a6-0754-3887-3ed21182e13f") },
                    { new Guid("afd09a83-1b35-a886-e69c-f88041045d06"), "debit cards", new Guid("2dff03f5-b2a6-0754-3887-3ed21182e13f") },
                    { new Guid("68d85a39-c836-d703-b26d-ad410e32ea15"), "cash", new Guid("5db6ffb8-0291-d8b3-ef8b-c185e50aff60") },
                    { new Guid("4e0dc2ef-b209-00b3-8b2f-66707f277095"), "debit cards", new Guid("5db6ffb8-0291-d8b3-ef8b-c185e50aff60") },
                    { new Guid("2e44d85a-6b0f-ca61-f0de-19a7c7640da5"), "loan", new Guid("5db6ffb8-0291-d8b3-ef8b-c185e50aff60") },
                    { new Guid("7fb1a4aa-30d4-e457-27d7-a0e417b1e7a6"), "debit cards", new Guid("aa6d55e2-a80c-86b6-a6d7-dc066193588b") },
                    { new Guid("9b6f93f6-eb4a-2023-79e9-7b66a0399d76"), "cash", new Guid("2dff03f5-b2a6-0754-3887-3ed21182e13f") },
                    { new Guid("67ad9a71-33fc-eeee-d04c-2001747068ed"), "cash", new Guid("202ecdfc-1c7c-a65c-9cae-ba26525d0fbf") },
                    { new Guid("74db33d2-a975-9a10-bb6a-12f56f44aaaf"), "loan", new Guid("aa6d55e2-a80c-86b6-a6d7-dc066193588b") },
                    { new Guid("f16cf34d-a86a-688e-2457-7fdf32e760d6"), "debit cards", new Guid("d9ef8592-92ac-3a6b-f3c0-e5bb2be30c1d") },
                    { new Guid("cc4e62ff-fcbe-a6f7-086c-595205a073c8"), "debit cards", new Guid("41874e01-577f-d190-db92-f2ff084447b1") },
                    { new Guid("1b0893cf-e039-db6a-47ea-b1e35fdd772c"), "bank account", new Guid("41874e01-577f-d190-db92-f2ff084447b1") },
                    { new Guid("f6540122-f316-28a0-3003-01a056358bbf"), "bank account", new Guid("aa6d55e2-a80c-86b6-a6d7-dc066193588b") },
                    { new Guid("af06d08e-76aa-239c-adbe-abf327dc5433"), "debit cards", new Guid("b4877cb9-87df-1f5b-f773-85d44b14472a") },
                    { new Guid("0d980a0b-62fc-7aa6-8ee8-ec38ad6f5dee"), "bank account", new Guid("b4877cb9-87df-1f5b-f773-85d44b14472a") },
                    { new Guid("4b91c2cb-432c-8c87-24a4-dc64ae05a4a7"), "loan", new Guid("41874e01-577f-d190-db92-f2ff084447b1") },
                    { new Guid("8a79ce02-083d-0c1d-da61-d4577104bca8"), "cash", new Guid("95851a0b-4379-2c6f-2a8c-21c28964763e") },
                    { new Guid("909af969-c847-b9db-a482-dd3affbcb403"), "bank account", new Guid("95851a0b-4379-2c6f-2a8c-21c28964763e") },
                    { new Guid("e1bd594f-94e3-a483-7af1-d1fc945a9ee2"), "debit cards", new Guid("95851a0b-4379-2c6f-2a8c-21c28964763e") },
                    { new Guid("de162a4f-d27d-413c-a6ea-b42ef892b7b4"), "cash", new Guid("d9ef8592-92ac-3a6b-f3c0-e5bb2be30c1d") },
                    { new Guid("48ca951c-73b7-26e5-7d91-d8f183c06298"), "loan", new Guid("b4877cb9-87df-1f5b-f773-85d44b14472a") }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "ParentId", "Type" },
                values: new object[,]
                {
                    { new Guid("81fbe3b4-177e-a65a-a9e7-64a89af3cfba"), "Parking", new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), 0 },
                    { new Guid("f71b164c-8dc7-ac60-1766-65011b261683"), "Public transport", new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), 0 },
                    { new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Taxi", new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), 0 },
                    { new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Coffe", new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), 0 },
                    { new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Street food", new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), 0 },
                    { new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Grocery", new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "Amount", "AssetId", "CategoryId", "Comment", "Date" },
                values: new object[,]
                {
                    { new Guid("c058f8aa-592a-fa8d-3aac-5a6ec1e0f271"), 222.962m, new Guid("cc4e62ff-fcbe-a6f7-086c-595205a073c8"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Quos odio quaerat voluptas modi aut vel.", new DateTime(2021, 4, 8, 4, 32, 28, 331, DateTimeKind.Local).AddTicks(2532) },
                    { new Guid("2c782023-212c-8c4d-1c86-3f15faffc419"), 7.379m, new Guid("9b6f93f6-eb4a-2023-79e9-7b66a0399d76"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Autem laboriosam modi occaecati qui.", new DateTime(2021, 4, 8, 11, 37, 57, 153, DateTimeKind.Local).AddTicks(241) },
                    { new Guid("2fe9e67d-7930-8c5f-06a5-215319e6c8cc"), 125.533m, new Guid("9b6f93f6-eb4a-2023-79e9-7b66a0399d76"), new Guid("ec65c208-2729-c1e9-d523-a898c5b77652"), "Perspiciatis maxime id ea repudiandae reprehenderit voluptas ratione aliquam.", new DateTime(2021, 4, 8, 3, 56, 53, 257, DateTimeKind.Local).AddTicks(6348) },
                    { new Guid("0f3efe56-c68e-2823-b19f-33754bb6b874"), 153.450m, new Guid("9b6f93f6-eb4a-2023-79e9-7b66a0399d76"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Animi amet est aut aliquid ratione omnis quia voluptatem ullam.", new DateTime(2021, 4, 8, 13, 20, 2, 668, DateTimeKind.Local).AddTicks(948) },
                    { new Guid("eef3d443-865a-9e77-9c94-6c457bcb86fc"), 36.573m, new Guid("9b6f93f6-eb4a-2023-79e9-7b66a0399d76"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Provident aperiam in vel aliquam sint.", new DateTime(2021, 4, 8, 11, 14, 7, 63, DateTimeKind.Local).AddTicks(840) },
                    { new Guid("3fe5c886-7c84-388a-05f5-732764a63d30"), 120.872m, new Guid("9b4dac38-472f-d78d-d908-6bdf363b1b35"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Maiores et perferendis voluptatem perferendis omnis ullam inventore iure pariatur.", new DateTime(2021, 4, 7, 21, 40, 36, 757, DateTimeKind.Local).AddTicks(7008) },
                    { new Guid("24ceaf1d-d7c6-e174-4e5d-dd2011f67e80"), 112.962m, new Guid("9b4dac38-472f-d78d-d908-6bdf363b1b35"), new Guid("ec65c208-2729-c1e9-d523-a898c5b77652"), "Sit omnis eum dolorem unde voluptatem maxime labore.", new DateTime(2021, 4, 7, 20, 32, 11, 274, DateTimeKind.Local).AddTicks(9954) },
                    { new Guid("fa6283af-63c6-94a0-a8e7-d3193afed887"), 142.765m, new Guid("9b4dac38-472f-d78d-d908-6bdf363b1b35"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "At quia nihil autem at quas et consectetur atque.", new DateTime(2021, 4, 8, 2, 49, 16, 252, DateTimeKind.Local).AddTicks(2636) },
                    { new Guid("b1d603c9-644a-f886-4349-2340c1a59e66"), 170.370m, new Guid("9b4dac38-472f-d78d-d908-6bdf363b1b35"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Consequuntur totam sint asperiores vel dolore fugit.", new DateTime(2021, 4, 8, 15, 22, 22, 862, DateTimeKind.Local).AddTicks(2666) },
                    { new Guid("93e81aef-db07-3aa9-5dab-be85649e85d0"), 117.702m, new Guid("93fff1e2-908b-4044-1ce5-5d6ce69cdf67"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Incidunt fugit at voluptatibus iste culpa et quis voluptatem.", new DateTime(2021, 4, 8, 2, 59, 23, 807, DateTimeKind.Local).AddTicks(789) },
                    { new Guid("c3afbe46-5476-e0a1-d650-feeafb034a24"), 173.689m, new Guid("93fff1e2-908b-4044-1ce5-5d6ce69cdf67"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Voluptatem ut sit harum similique voluptatum.", new DateTime(2021, 4, 8, 9, 20, 0, 722, DateTimeKind.Local).AddTicks(6068) },
                    { new Guid("71d0452d-529d-97c3-23a4-6a6e48dbf326"), 54.080m, new Guid("93fff1e2-908b-4044-1ce5-5d6ce69cdf67"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Et iusto deserunt velit molestiae et voluptatem alias laborum rerum.", new DateTime(2021, 4, 8, 11, 47, 43, 935, DateTimeKind.Local).AddTicks(3656) },
                    { new Guid("e9bbaf64-9d65-f037-a499-715274a2c281"), 144.562m, new Guid("93fff1e2-908b-4044-1ce5-5d6ce69cdf67"), new Guid("f71b164c-8dc7-ac60-1766-65011b261683"), "Reiciendis ea totam deserunt et velit nostrum voluptatum consequatur.", new DateTime(2021, 4, 8, 8, 40, 39, 691, DateTimeKind.Local).AddTicks(2289) },
                    { new Guid("1e432d50-81e2-25dc-b0e2-84a826edc57b"), 143.793m, new Guid("485183ec-1d45-e3a4-dac4-061921194f8e"), new Guid("81fbe3b4-177e-a65a-a9e7-64a89af3cfba"), "Dolorum rem illum dolorum deserunt omnis commodi.", new DateTime(2021, 4, 7, 20, 51, 1, 169, DateTimeKind.Local).AddTicks(4693) },
                    { new Guid("8e3a414e-b6ca-5273-0c09-08a5397f8c97"), 212.178m, new Guid("5bc77c97-6eb8-c7ef-dc05-3347fb010b3e"), new Guid("ec65c208-2729-c1e9-d523-a898c5b77652"), "Qui tenetur quia animi dolorem velit.", new DateTime(2021, 4, 8, 8, 53, 16, 929, DateTimeKind.Local).AddTicks(7262) },
                    { new Guid("b452e361-7475-a5f9-4cd6-f2726743e454"), 52.197m, new Guid("5bc77c97-6eb8-c7ef-dc05-3347fb010b3e"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Vitae impedit et cumque quia nobis.", new DateTime(2021, 4, 8, 8, 22, 39, 553, DateTimeKind.Local).AddTicks(2041) },
                    { new Guid("d10b25d6-8bf2-0cca-c490-0dab48245609"), 82.940m, new Guid("5bc77c97-6eb8-c7ef-dc05-3347fb010b3e"), new Guid("ec65c208-2729-c1e9-d523-a898c5b77652"), "Nam totam ipsa incidunt et tenetur nesciunt aut.", new DateTime(2021, 4, 8, 17, 49, 35, 988, DateTimeKind.Local).AddTicks(9874) },
                    { new Guid("91f308f1-2846-32bd-3ecf-ca58a7e5fe31"), 141.711m, new Guid("4f49d75e-a01f-a146-bf33-cc6bc3b4ccd3"), new Guid("f71b164c-8dc7-ac60-1766-65011b261683"), "Iste soluta dolor et nulla eligendi illo adipisci nisi eaque.", new DateTime(2021, 4, 8, 17, 40, 43, 141, DateTimeKind.Local).AddTicks(5419) },
                    { new Guid("c4a91309-9468-c5ff-e494-bd9e0ab8cbdd"), 106.519m, new Guid("4f49d75e-a01f-a146-bf33-cc6bc3b4ccd3"), new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Qui quia aspernatur ut iure quasi quasi consequuntur laudantium.", new DateTime(2021, 4, 8, 16, 13, 7, 890, DateTimeKind.Local).AddTicks(2582) },
                    { new Guid("6c3224ed-2417-315f-d0dc-03385f586dc9"), 137.019m, new Guid("4f49d75e-a01f-a146-bf33-cc6bc3b4ccd3"), new Guid("81fbe3b4-177e-a65a-a9e7-64a89af3cfba"), "Ut est error natus ut occaecati qui sint.", new DateTime(2021, 4, 8, 15, 40, 58, 440, DateTimeKind.Local).AddTicks(6111) },
                    { new Guid("053c4ca4-84af-adae-a1ec-e91600d5c369"), 105.251m, new Guid("4f49d75e-a01f-a146-bf33-cc6bc3b4ccd3"), new Guid("f71b164c-8dc7-ac60-1766-65011b261683"), "Exercitationem nesciunt accusantium rerum tempora libero atque et facilis corporis.", new DateTime(2021, 4, 7, 20, 19, 12, 653, DateTimeKind.Local).AddTicks(6255) },
                    { new Guid("fd0e8194-bcfb-9b70-3780-60b2e5004556"), 55.750m, new Guid("7e106639-e6d0-0e8c-e337-caaa6a576d65"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Illo minus aspernatur deleniti atque provident.", new DateTime(2021, 4, 7, 18, 42, 49, 516, DateTimeKind.Local).AddTicks(817) },
                    { new Guid("dfe2b64b-4b24-360f-6ef8-14fc91340522"), 131.290m, new Guid("7e106639-e6d0-0e8c-e337-caaa6a576d65"), new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), "Eos temporibus aperiam accusamus et totam quod cumque.", new DateTime(2021, 4, 7, 20, 45, 45, 103, DateTimeKind.Local).AddTicks(329) },
                    { new Guid("3f8384f5-1432-9d06-e1bc-511a5f85fdf5"), 25.422m, new Guid("7e106639-e6d0-0e8c-e337-caaa6a576d65"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Laborum quia quisquam excepturi et quia ipsa eum consectetur ut.", new DateTime(2021, 4, 8, 4, 55, 44, 675, DateTimeKind.Local).AddTicks(7448) },
                    { new Guid("a844a52d-fedd-b47e-9d1a-cf9375a10c1b"), 97.394m, new Guid("7e106639-e6d0-0e8c-e337-caaa6a576d65"), new Guid("ec65c208-2729-c1e9-d523-a898c5b77652"), "Neque harum in perspiciatis magnam incidunt eveniet mollitia porro sint.", new DateTime(2021, 4, 8, 12, 41, 9, 146, DateTimeKind.Local).AddTicks(9416) },
                    { new Guid("25fd5cbe-b95f-464b-bfba-d0cefd9fcd88"), 125.721m, new Guid("a7ffc400-307d-1168-06be-0c573b33419e"), new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Rerum ut a dignissimos dicta.", new DateTime(2021, 4, 8, 4, 23, 58, 12, DateTimeKind.Local).AddTicks(6136) },
                    { new Guid("95a20541-d884-902c-9b01-c666df32ab28"), 127.749m, new Guid("a7ffc400-307d-1168-06be-0c573b33419e"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Enim modi et dolor eum ea.", new DateTime(2021, 4, 8, 17, 40, 29, 784, DateTimeKind.Local).AddTicks(7093) },
                    { new Guid("449bed21-b930-daf2-abe1-3e5935d42ab1"), 211.446m, new Guid("5bc77c97-6eb8-c7ef-dc05-3347fb010b3e"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Numquam ipsum fugiat aut est nobis ut.", new DateTime(2021, 4, 8, 11, 22, 56, 57, DateTimeKind.Local).AddTicks(7695) },
                    { new Guid("98a00718-007f-73bf-6482-78f919475521"), 117.920m, new Guid("a7ffc400-307d-1168-06be-0c573b33419e"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Earum sed eum totam aliquam quo.", new DateTime(2021, 4, 7, 18, 22, 51, 750, DateTimeKind.Local).AddTicks(9644) },
                    { new Guid("f075fe23-7ee1-dc9b-f309-6d390562ef4a"), 116.094m, new Guid("485183ec-1d45-e3a4-dac4-061921194f8e"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Magnam sapiente quia sit qui voluptas sequi.", new DateTime(2021, 4, 8, 7, 7, 53, 67, DateTimeKind.Local).AddTicks(1457) },
                    { new Guid("f582d850-c661-a516-0117-a6a9c9102b9d"), 153.738m, new Guid("485183ec-1d45-e3a4-dac4-061921194f8e"), new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Ut assumenda veritatis laboriosam repudiandae molestiae qui repellat.", new DateTime(2021, 4, 8, 16, 14, 51, 516, DateTimeKind.Local).AddTicks(4772) },
                    { new Guid("01836419-a690-6b65-e6ef-aa1446f35e40"), 56.587m, new Guid("74db33d2-a975-9a10-bb6a-12f56f44aaaf"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Iste qui ducimus accusamus dolorem sit.", new DateTime(2021, 4, 8, 2, 26, 16, 884, DateTimeKind.Local).AddTicks(5954) },
                    { new Guid("d8339ee3-0351-4494-50e1-3ef28cbdbe2d"), 206.378m, new Guid("74db33d2-a975-9a10-bb6a-12f56f44aaaf"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Dolorem laboriosam a non ex.", new DateTime(2021, 4, 8, 5, 51, 0, 975, DateTimeKind.Local).AddTicks(4023) },
                    { new Guid("d5636264-9faa-3178-20d2-49481e4561d5"), 23.832m, new Guid("f6540122-f316-28a0-3003-01a056358bbf"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Iusto labore incidunt qui eum vel repudiandae quod molestiae labore.", new DateTime(2021, 4, 8, 0, 50, 57, 941, DateTimeKind.Local).AddTicks(3963) },
                    { new Guid("90b441a9-3406-65b6-f71a-fa81b723ac90"), 162.136m, new Guid("f6540122-f316-28a0-3003-01a056358bbf"), new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Sunt tempora mollitia odio est et autem.", new DateTime(2021, 4, 8, 1, 57, 46, 379, DateTimeKind.Local).AddTicks(4401) },
                    { new Guid("1f4af05b-d357-dbe5-6187-d94e52fbc6cd"), 184.077m, new Guid("f6540122-f316-28a0-3003-01a056358bbf"), new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Nulla earum dicta a occaecati veritatis commodi fugiat.", new DateTime(2021, 4, 8, 14, 26, 25, 8, DateTimeKind.Local).AddTicks(358) },
                    { new Guid("5b8d6993-b13c-e14d-f611-55423a52559d"), 172.080m, new Guid("f6540122-f316-28a0-3003-01a056358bbf"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Qui ad nemo accusamus dolor et tempora pariatur non quidem.", new DateTime(2021, 4, 8, 2, 4, 53, 295, DateTimeKind.Local).AddTicks(1225) },
                    { new Guid("12966126-eb2e-733d-369e-382630490d1c"), 132.992m, new Guid("7fb1a4aa-30d4-e457-27d7-a0e417b1e7a6"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Sit itaque tempore voluptas tenetur nisi.", new DateTime(2021, 4, 8, 9, 49, 43, 505, DateTimeKind.Local).AddTicks(7536) },
                    { new Guid("632c2c65-721d-55eb-683d-921035ad5007"), 182.516m, new Guid("7fb1a4aa-30d4-e457-27d7-a0e417b1e7a6"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Quo consequatur culpa dolor unde.", new DateTime(2021, 4, 8, 3, 20, 28, 326, DateTimeKind.Local).AddTicks(4455) },
                    { new Guid("e28c14c0-ae31-3eea-5304-655293667f07"), 203.377m, new Guid("7fb1a4aa-30d4-e457-27d7-a0e417b1e7a6"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Debitis facilis architecto magnam pariatur recusandae sed exercitationem vero est.", new DateTime(2021, 4, 8, 14, 42, 46, 604, DateTimeKind.Local).AddTicks(7113) },
                    { new Guid("0f6f598b-2443-be63-9bde-8678389aec7d"), 24.346m, new Guid("7fb1a4aa-30d4-e457-27d7-a0e417b1e7a6"), new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), "Reprehenderit provident omnis quaerat perferendis cupiditate ut minus architecto nihil.", new DateTime(2021, 4, 8, 16, 32, 1, 570, DateTimeKind.Local).AddTicks(4439) },
                    { new Guid("3a79e43d-bd0d-5a08-4d96-28c9112f4406"), 67.603m, new Guid("2e44d85a-6b0f-ca61-f0de-19a7c7640da5"), new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), "Nesciunt illo placeat voluptatem odit labore.", new DateTime(2021, 4, 8, 17, 27, 50, 439, DateTimeKind.Local).AddTicks(3435) }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "Amount", "AssetId", "CategoryId", "Comment", "Date" },
                values: new object[,]
                {
                    { new Guid("82421306-c2d9-b200-4557-f4d79c1fda7f"), 20.040m, new Guid("2e44d85a-6b0f-ca61-f0de-19a7c7640da5"), new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Voluptas consequatur enim accusantium ut.", new DateTime(2021, 4, 8, 7, 39, 28, 914, DateTimeKind.Local).AddTicks(6482) },
                    { new Guid("64dc153a-226c-b95f-263a-f1a22a8b11d2"), 131.387m, new Guid("485183ec-1d45-e3a4-dac4-061921194f8e"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Et eaque natus enim consequuntur consequuntur molestiae aut dicta quo.", new DateTime(2021, 4, 8, 2, 20, 54, 752, DateTimeKind.Local).AddTicks(2454) },
                    { new Guid("a367b927-3c01-2193-9d3b-0c9309070733"), 127.406m, new Guid("2e44d85a-6b0f-ca61-f0de-19a7c7640da5"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Nihil ut qui harum autem omnis quia eligendi rerum.", new DateTime(2021, 4, 8, 2, 39, 23, 989, DateTimeKind.Local).AddTicks(9261) },
                    { new Guid("ed9e5307-c549-e1ca-c3f0-c04ccbe0ce73"), 30.429m, new Guid("4e0dc2ef-b209-00b3-8b2f-66707f277095"), new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Velit ad quia voluptatem rem.", new DateTime(2021, 4, 8, 5, 0, 32, 662, DateTimeKind.Local).AddTicks(1961) },
                    { new Guid("2339c811-8560-ac09-07dc-56e185d39144"), 175.891m, new Guid("4e0dc2ef-b209-00b3-8b2f-66707f277095"), new Guid("ec65c208-2729-c1e9-d523-a898c5b77652"), "Sed rerum omnis adipisci esse.", new DateTime(2021, 4, 8, 12, 32, 55, 268, DateTimeKind.Local).AddTicks(1116) },
                    { new Guid("d3a767fe-bf6f-8802-86ef-41537d0d0732"), 212.809m, new Guid("4e0dc2ef-b209-00b3-8b2f-66707f277095"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Vitae est vero architecto labore at provident.", new DateTime(2021, 4, 8, 3, 15, 31, 84, DateTimeKind.Local).AddTicks(9819) },
                    { new Guid("d5670a40-c3f3-ab43-6e83-2a5044d51acb"), 55.898m, new Guid("4e0dc2ef-b209-00b3-8b2f-66707f277095"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Cum ipsum dolores fugiat quia temporibus magni quae.", new DateTime(2021, 4, 8, 9, 4, 52, 297, DateTimeKind.Local).AddTicks(3429) },
                    { new Guid("b97a20e7-420a-ed93-c434-17c0b876b639"), 34.682m, new Guid("68d85a39-c836-d703-b26d-ad410e32ea15"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Delectus vero ipsam et qui quia.", new DateTime(2021, 4, 8, 14, 54, 54, 99, DateTimeKind.Local).AddTicks(8303) },
                    { new Guid("33c0564f-5685-a4a4-094f-17adb826cdb4"), 83.505m, new Guid("68d85a39-c836-d703-b26d-ad410e32ea15"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Adipisci praesentium itaque enim labore repellat.", new DateTime(2021, 4, 7, 23, 36, 36, 759, DateTimeKind.Local).AddTicks(1035) },
                    { new Guid("5d80d567-9529-14bc-8bd7-f43ecc5addd2"), 40.143m, new Guid("68d85a39-c836-d703-b26d-ad410e32ea15"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Qui vel accusamus beatae error assumenda accusantium officia.", new DateTime(2021, 4, 8, 14, 31, 19, 747, DateTimeKind.Local).AddTicks(1250) },
                    { new Guid("e2f48795-790c-ac8a-4143-753a598c7146"), 15.431m, new Guid("68d85a39-c836-d703-b26d-ad410e32ea15"), new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), "Ut dignissimos in qui sed.", new DateTime(2021, 4, 8, 15, 10, 12, 579, DateTimeKind.Local).AddTicks(489) },
                    { new Guid("65afd0eb-7b6c-af32-6757-5ccb19a70adf"), 222.221m, new Guid("afd09a83-1b35-a886-e69c-f88041045d06"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Est sunt quisquam accusantium magnam.", new DateTime(2021, 4, 8, 7, 47, 43, 730, DateTimeKind.Local).AddTicks(773) },
                    { new Guid("c5a24436-462f-bee9-f9ec-7822ba9ca84d"), 96.493m, new Guid("afd09a83-1b35-a886-e69c-f88041045d06"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Vitae libero nihil et rerum.", new DateTime(2021, 4, 8, 0, 18, 36, 123, DateTimeKind.Local).AddTicks(7835) },
                    { new Guid("7bfea0fd-a18d-de6d-d650-c95ee026117c"), 20.681m, new Guid("afd09a83-1b35-a886-e69c-f88041045d06"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Dolor occaecati officiis saepe id.", new DateTime(2021, 4, 8, 12, 13, 34, 284, DateTimeKind.Local).AddTicks(2796) },
                    { new Guid("dcc72bc6-e84a-19ea-2035-294abbccd1c9"), 41.062m, new Guid("afd09a83-1b35-a886-e69c-f88041045d06"), new Guid("f71b164c-8dc7-ac60-1766-65011b261683"), "Aut est rerum est voluptatem iusto dignissimos.", new DateTime(2021, 4, 7, 19, 18, 33, 870, DateTimeKind.Local).AddTicks(7009) },
                    { new Guid("4dbe89ac-e9ba-19b9-e958-316bbebd168b"), 169.609m, new Guid("2e44d85a-6b0f-ca61-f0de-19a7c7640da5"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Eum repudiandae vel cum voluptates et.", new DateTime(2021, 4, 7, 23, 9, 37, 414, DateTimeKind.Local).AddTicks(9370) },
                    { new Guid("0c9274ed-b32e-6608-fe5e-336b9b70fcb8"), 90.126m, new Guid("a7ffc400-307d-1168-06be-0c573b33419e"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Assumenda velit et magni libero animi.", new DateTime(2021, 4, 7, 21, 10, 3, 27, DateTimeKind.Local).AddTicks(6367) },
                    { new Guid("5b21ee61-f652-050a-48fb-5e8775662eef"), 23.475m, new Guid("1768feb4-6728-0f04-562a-134b2403471a"), new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Sint aspernatur debitis quae ipsa.", new DateTime(2021, 4, 8, 3, 17, 29, 449, DateTimeKind.Local).AddTicks(6448) },
                    { new Guid("dc7ac9ba-2e0a-a5b3-e4c0-218df7c2f3c3"), 43.520m, new Guid("1768feb4-6728-0f04-562a-134b2403471a"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Fugiat veritatis beatae et maiores aut ut non molestias neque.", new DateTime(2021, 4, 8, 7, 25, 6, 818, DateTimeKind.Local).AddTicks(4274) },
                    { new Guid("aee6c433-1e12-a6db-7a85-8281cb610ca1"), 198.571m, new Guid("8a79ce02-083d-0c1d-da61-d4577104bca8"), new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), "Ut nihil nihil numquam dolores quis error.", new DateTime(2021, 4, 7, 18, 41, 43, 291, DateTimeKind.Local).AddTicks(2111) },
                    { new Guid("da232ae2-25ea-740e-1bb3-c0c64e410087"), 82.481m, new Guid("8a79ce02-083d-0c1d-da61-d4577104bca8"), new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), "Alias cum perspiciatis qui ratione.", new DateTime(2021, 4, 8, 9, 44, 48, 216, DateTimeKind.Local) },
                    { new Guid("e523db07-6892-6891-aca4-a64c32b09577"), 206.095m, new Guid("8a79ce02-083d-0c1d-da61-d4577104bca8"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Qui reiciendis quam consequatur repudiandae iure est adipisci.", new DateTime(2021, 4, 7, 21, 13, 42, 401, DateTimeKind.Local).AddTicks(1112) },
                    { new Guid("db53e5b0-82f8-4f16-3f99-532ee0aaac2c"), 9.284m, new Guid("48ca951c-73b7-26e5-7d91-d8f183c06298"), new Guid("f71b164c-8dc7-ac60-1766-65011b261683"), "Nemo nesciunt suscipit praesentium accusantium molestiae voluptas.", new DateTime(2021, 4, 8, 14, 40, 17, 633, DateTimeKind.Local).AddTicks(3753) },
                    { new Guid("34d59fc8-eb39-c440-cb19-91f88245b4c6"), 44.408m, new Guid("48ca951c-73b7-26e5-7d91-d8f183c06298"), new Guid("81fbe3b4-177e-a65a-a9e7-64a89af3cfba"), "Et et quibusdam quos voluptatem magnam tenetur ut sed quas.", new DateTime(2021, 4, 8, 6, 17, 57, 430, DateTimeKind.Local).AddTicks(3542) },
                    { new Guid("433540bd-6471-22c0-eb84-798493f2acc3"), 133.680m, new Guid("48ca951c-73b7-26e5-7d91-d8f183c06298"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Sed ipsum voluptas ut quo eum non.", new DateTime(2021, 4, 8, 2, 16, 49, 80, DateTimeKind.Local).AddTicks(6585) },
                    { new Guid("9773d7b3-0c82-d54e-6ae6-05d6b2693126"), 50.544m, new Guid("48ca951c-73b7-26e5-7d91-d8f183c06298"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Ab deserunt et autem maxime.", new DateTime(2021, 4, 7, 23, 17, 51, 997, DateTimeKind.Local).AddTicks(9925) },
                    { new Guid("ef6710c6-cec7-5037-f82b-75b811138f6e"), 147.493m, new Guid("0d980a0b-62fc-7aa6-8ee8-ec38ad6f5dee"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Iste voluptates sint quod cupiditate ratione voluptatum.", new DateTime(2021, 4, 8, 17, 53, 34, 887, DateTimeKind.Local).AddTicks(9062) },
                    { new Guid("85e2c202-526f-39be-9b7a-4ef49e80a081"), 59.301m, new Guid("0d980a0b-62fc-7aa6-8ee8-ec38ad6f5dee"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Aut dolor neque consequatur animi quis nemo est ut.", new DateTime(2021, 4, 8, 10, 55, 38, 403, DateTimeKind.Local).AddTicks(3881) },
                    { new Guid("3e5b5b68-d084-33f9-7d9a-c7764aaf0abc"), 136.276m, new Guid("0d980a0b-62fc-7aa6-8ee8-ec38ad6f5dee"), new Guid("ec65c208-2729-c1e9-d523-a898c5b77652"), "Sit repellendus voluptas ab aliquid tenetur.", new DateTime(2021, 4, 8, 9, 38, 29, 134, DateTimeKind.Local).AddTicks(3064) },
                    { new Guid("5c80b767-d503-33aa-2351-99b59b47b796"), 168.522m, new Guid("0d980a0b-62fc-7aa6-8ee8-ec38ad6f5dee"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Culpa tenetur tempore vero iste.", new DateTime(2021, 4, 8, 11, 27, 54, 948, DateTimeKind.Local).AddTicks(3013) },
                    { new Guid("a42406ed-d4a2-91df-027f-f7a6b2df67b1"), 107.855m, new Guid("af06d08e-76aa-239c-adbe-abf327dc5433"), new Guid("81fbe3b4-177e-a65a-a9e7-64a89af3cfba"), "Nostrum nihil ratione tenetur rerum aut autem consequuntur velit.", new DateTime(2021, 4, 7, 22, 44, 40, 467, DateTimeKind.Local).AddTicks(6399) },
                    { new Guid("8d8ad8f4-8d77-b733-6028-c50895e520d4"), 226.046m, new Guid("8a79ce02-083d-0c1d-da61-d4577104bca8"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Et corrupti sed amet eum natus quia voluptates maiores voluptas.", new DateTime(2021, 4, 8, 14, 31, 31, 409, DateTimeKind.Local).AddTicks(7273) },
                    { new Guid("54dbd454-02a1-6ced-a9c2-b057c7f46e94"), 69.576m, new Guid("af06d08e-76aa-239c-adbe-abf327dc5433"), new Guid("f71b164c-8dc7-ac60-1766-65011b261683"), "Eius est minima ut est delectus magni cum sit fugit.", new DateTime(2021, 4, 8, 12, 37, 11, 565, DateTimeKind.Local).AddTicks(7022) },
                    { new Guid("3246e79a-216f-e59c-2774-feba8b98ef96"), 225.074m, new Guid("af06d08e-76aa-239c-adbe-abf327dc5433"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Eos debitis deserunt quod consequatur officiis voluptas earum.", new DateTime(2021, 4, 8, 1, 29, 51, 263, DateTimeKind.Local).AddTicks(1625) },
                    { new Guid("918e62b5-7f82-2914-18dc-8289a8591116"), 141.017m, new Guid("4b91c2cb-432c-8c87-24a4-dc64ae05a4a7"), new Guid("ec65c208-2729-c1e9-d523-a898c5b77652"), "Et quae distinctio deleniti vero.", new DateTime(2021, 4, 7, 23, 0, 14, 589, DateTimeKind.Local).AddTicks(2145) },
                    { new Guid("10cadd18-602a-1c48-1b6f-ab142f2a9576"), 59.152m, new Guid("4b91c2cb-432c-8c87-24a4-dc64ae05a4a7"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Sed odio maxime fuga repudiandae.", new DateTime(2021, 4, 8, 5, 29, 16, 151, DateTimeKind.Local).AddTicks(499) },
                    { new Guid("347ecfa1-5289-f452-5f54-b984715f4bca"), 47.998m, new Guid("4b91c2cb-432c-8c87-24a4-dc64ae05a4a7"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Qui eos similique soluta omnis dolores sint atque.", new DateTime(2021, 4, 8, 4, 30, 9, 862, DateTimeKind.Local).AddTicks(2536) },
                    { new Guid("fb85da50-3ed4-eabe-ec99-a33466821ff5"), 183.080m, new Guid("4b91c2cb-432c-8c87-24a4-dc64ae05a4a7"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Voluptas in temporibus nihil eum corrupti ducimus assumenda.", new DateTime(2021, 4, 8, 0, 30, 38, 717, DateTimeKind.Local).AddTicks(591) },
                    { new Guid("3b94d9ab-cf9d-cfa3-e54f-8dc32f493764"), 6.484m, new Guid("1b0893cf-e039-db6a-47ea-b1e35fdd772c"), new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Qui sed quia praesentium quas eligendi ex.", new DateTime(2021, 4, 8, 17, 32, 1, 185, DateTimeKind.Local).AddTicks(9726) },
                    { new Guid("ab38009d-34d8-9536-c52e-dfd23525eeda"), 105.568m, new Guid("1b0893cf-e039-db6a-47ea-b1e35fdd772c"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Temporibus aut sunt magnam at cupiditate consequatur deserunt.", new DateTime(2021, 4, 8, 5, 56, 45, 69, DateTimeKind.Local).AddTicks(9139) },
                    { new Guid("ea815653-cf40-fb1d-65f7-66defd93ea52"), 61.811m, new Guid("1b0893cf-e039-db6a-47ea-b1e35fdd772c"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "A voluptates voluptatem enim ratione.", new DateTime(2021, 4, 7, 22, 27, 51, 313, DateTimeKind.Local).AddTicks(7156) },
                    { new Guid("3052aed5-24b7-82c2-3554-2065bef7150e"), 43.498m, new Guid("1b0893cf-e039-db6a-47ea-b1e35fdd772c"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Rerum sit aut placeat architecto quam sed quae.", new DateTime(2021, 4, 8, 17, 57, 10, 689, DateTimeKind.Local).AddTicks(8243) }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "Amount", "AssetId", "CategoryId", "Comment", "Date" },
                values: new object[,]
                {
                    { new Guid("819c7e21-8929-aaf2-b827-1d03c01520a6"), 66.800m, new Guid("cc4e62ff-fcbe-a6f7-086c-595205a073c8"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Eos eos ea blanditiis neque voluptatum nobis.", new DateTime(2021, 4, 8, 4, 25, 31, 923, DateTimeKind.Local).AddTicks(9961) },
                    { new Guid("62579288-0097-f98f-a3b4-f0a18f48eac0"), 97.507m, new Guid("cc4e62ff-fcbe-a6f7-086c-595205a073c8"), new Guid("f71b164c-8dc7-ac60-1766-65011b261683"), "Officia aut et minima eaque ea alias harum voluptates.", new DateTime(2021, 4, 7, 23, 6, 40, 657, DateTimeKind.Local).AddTicks(1616) },
                    { new Guid("1d9809d9-8412-1a01-be1d-92b9b9d49637"), 178.750m, new Guid("cc4e62ff-fcbe-a6f7-086c-595205a073c8"), new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Necessitatibus qui quaerat aut et.", new DateTime(2021, 4, 8, 4, 12, 2, 290, DateTimeKind.Local).AddTicks(2158) },
                    { new Guid("91862444-c810-97e8-cef6-a8bae5a381e5"), 28.000m, new Guid("af06d08e-76aa-239c-adbe-abf327dc5433"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Sit error veniam dicta a at quisquam eum sint eos.", new DateTime(2021, 4, 8, 4, 1, 52, 556, DateTimeKind.Local).AddTicks(2831) },
                    { new Guid("48600ac5-cde6-f8ef-0af3-98aaab795a53"), 66.275m, new Guid("909af969-c847-b9db-a482-dd3affbcb403"), new Guid("81fbe3b4-177e-a65a-a9e7-64a89af3cfba"), "Dolorem magnam aut eum magni ut consequuntur.", new DateTime(2021, 4, 7, 23, 25, 16, 74, DateTimeKind.Local).AddTicks(2641) },
                    { new Guid("d01a931e-0f1f-63f1-bba8-4cfe52e4c373"), 167.335m, new Guid("909af969-c847-b9db-a482-dd3affbcb403"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Tempore iste et reprehenderit quo quia est.", new DateTime(2021, 4, 7, 21, 29, 44, 6, DateTimeKind.Local).AddTicks(5328) },
                    { new Guid("406c22d4-a801-d03d-64f0-22799ab9169f"), 181.543m, new Guid("909af969-c847-b9db-a482-dd3affbcb403"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Quasi in cum suscipit libero voluptatem sit blanditiis ducimus ab.", new DateTime(2021, 4, 8, 10, 53, 59, 817, DateTimeKind.Local).AddTicks(1557) },
                    { new Guid("a142a010-373b-3e84-100d-c084e2522a12"), 122.563m, new Guid("1768feb4-6728-0f04-562a-134b2403471a"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Non dolores repellendus enim ut voluptatem veniam sit eveniet officiis.", new DateTime(2021, 4, 7, 18, 33, 24, 673, DateTimeKind.Local).AddTicks(4502) },
                    { new Guid("b246e1af-1a28-f6ce-4620-f7a6cb08cfb3"), 2.121m, new Guid("1768feb4-6728-0f04-562a-134b2403471a"), new Guid("81fbe3b4-177e-a65a-a9e7-64a89af3cfba"), "Delectus officiis qui quasi ut adipisci.", new DateTime(2021, 4, 8, 5, 1, 50, 219, DateTimeKind.Local).AddTicks(5820) },
                    { new Guid("517a4b8d-28ec-efc0-0637-0b6df808747a"), 133.715m, new Guid("e71f2d91-3960-345c-1cc9-7930669412c5"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Laboriosam vitae nihil nesciunt quo dolorum eos.", new DateTime(2021, 4, 7, 22, 28, 4, 199, DateTimeKind.Local).AddTicks(3762) },
                    { new Guid("6467bde1-9284-499a-93f4-c9beb97ff4b2"), 201.882m, new Guid("e71f2d91-3960-345c-1cc9-7930669412c5"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Ipsam aut voluptatem voluptas rem.", new DateTime(2021, 4, 8, 3, 11, 32, 591, DateTimeKind.Local).AddTicks(8990) },
                    { new Guid("1ead7492-e71f-72df-e718-c9d55c8c0614"), 22.166m, new Guid("e71f2d91-3960-345c-1cc9-7930669412c5"), new Guid("e411e14b-72d6-7831-f0ba-3aace0aab8eb"), "Nihil repudiandae soluta aliquid impedit magni quisquam eum id nesciunt.", new DateTime(2021, 4, 8, 17, 36, 32, 46, DateTimeKind.Local).AddTicks(7651) },
                    { new Guid("9ae43994-bb8f-16ad-0748-68b2dca831a1"), 189.665m, new Guid("e71f2d91-3960-345c-1cc9-7930669412c5"), new Guid("906112e3-a772-356a-bb74-4ddf29b81123"), "Qui unde aut vitae sed illo omnis saepe.", new DateTime(2021, 4, 7, 19, 3, 14, 826, DateTimeKind.Local).AddTicks(3497) },
                    { new Guid("9f35382e-7973-7409-abcc-b358900aa30e"), 63.655m, new Guid("67ad9a71-33fc-eeee-d04c-2001747068ed"), new Guid("f71b164c-8dc7-ac60-1766-65011b261683"), "Exercitationem assumenda sint dolores nesciunt soluta minus ut.", new DateTime(2021, 4, 8, 3, 35, 50, 821, DateTimeKind.Local).AddTicks(1561) },
                    { new Guid("b84c1827-7a90-dbbe-4e3d-e8dc2ce61cdc"), 43.068m, new Guid("67ad9a71-33fc-eeee-d04c-2001747068ed"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Odio eaque placeat sed ex illum mollitia quasi.", new DateTime(2021, 4, 7, 20, 30, 56, 938, DateTimeKind.Local).AddTicks(8219) },
                    { new Guid("06e0a742-8c31-84f8-43d3-4fe5f24b45ac"), 210.261m, new Guid("67ad9a71-33fc-eeee-d04c-2001747068ed"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Ut cum quasi enim ipsum.", new DateTime(2021, 4, 8, 7, 8, 6, 809, DateTimeKind.Local).AddTicks(4080) },
                    { new Guid("65ee39a5-ca8c-7f9c-90bd-3217a9d4f28e"), 216.354m, new Guid("67ad9a71-33fc-eeee-d04c-2001747068ed"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "At facilis repellendus soluta quos sed autem praesentium.", new DateTime(2021, 4, 8, 1, 30, 0, 210, DateTimeKind.Local).AddTicks(4390) },
                    { new Guid("9adc5485-aab5-7551-9dbd-3138dbb08eca"), 130.840m, new Guid("52e5875f-646e-fdf3-9ec4-68da89eca8c8"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Eos ducimus temporibus culpa neque ut officiis non sed.", new DateTime(2021, 4, 8, 18, 0, 21, 664, DateTimeKind.Local).AddTicks(5815) },
                    { new Guid("ce66e823-f150-2a5b-72dd-681e71b0bf22"), 40.841m, new Guid("52e5875f-646e-fdf3-9ec4-68da89eca8c8"), new Guid("81fbe3b4-177e-a65a-a9e7-64a89af3cfba"), "Autem nisi optio ipsum tempore.", new DateTime(2021, 4, 8, 17, 0, 29, 687, DateTimeKind.Local).AddTicks(6817) },
                    { new Guid("f8f616cd-e171-9f1a-a900-7f26ffdc797f"), 74.911m, new Guid("52e5875f-646e-fdf3-9ec4-68da89eca8c8"), new Guid("ec65c208-2729-c1e9-d523-a898c5b77652"), "Consequatur laborum quae ut optio ut.", new DateTime(2021, 4, 8, 3, 4, 56, 515, DateTimeKind.Local).AddTicks(5654) },
                    { new Guid("dca4e85c-91fe-40d9-f45f-17e292dac1ed"), 133.514m, new Guid("52e5875f-646e-fdf3-9ec4-68da89eca8c8"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Tempora quidem enim excepturi iste necessitatibus sed eius.", new DateTime(2021, 4, 8, 5, 15, 5, 971, DateTimeKind.Local).AddTicks(8995) },
                    { new Guid("a14bd285-733c-76cc-874d-dd7db7d91d6d"), 62.492m, new Guid("f16cf34d-a86a-688e-2457-7fdf32e760d6"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Eum aliquid nostrum qui fugiat et officia tenetur.", new DateTime(2021, 4, 8, 1, 16, 38, 676, DateTimeKind.Local).AddTicks(1277) },
                    { new Guid("55542449-5efc-4013-0153-565e50493ba6"), 30.394m, new Guid("f16cf34d-a86a-688e-2457-7fdf32e760d6"), new Guid("81fbe3b4-177e-a65a-a9e7-64a89af3cfba"), "Voluptas optio omnis enim dolores quas.", new DateTime(2021, 4, 8, 4, 11, 31, 448, DateTimeKind.Local).AddTicks(9086) },
                    { new Guid("b39d7cf8-72d0-d331-b437-31ade0fe40a9"), 48.715m, new Guid("f16cf34d-a86a-688e-2457-7fdf32e760d6"), new Guid("8daa20dc-c632-19d8-c8d3-934bb74ed75a"), "Necessitatibus quis dolor non eligendi.", new DateTime(2021, 4, 8, 3, 21, 44, 297, DateTimeKind.Local).AddTicks(3342) },
                    { new Guid("2602ec56-d166-d24b-fc04-1aadd8562c3e"), 170.801m, new Guid("f16cf34d-a86a-688e-2457-7fdf32e760d6"), new Guid("f71b164c-8dc7-ac60-1766-65011b261683"), "Atque nesciunt rerum omnis minus consequuntur fuga.", new DateTime(2021, 4, 8, 14, 7, 34, 932, DateTimeKind.Local).AddTicks(9898) },
                    { new Guid("84c4e155-5b7e-3e14-29a0-3a5814b24a13"), 218.352m, new Guid("de162a4f-d27d-413c-a6ea-b42ef892b7b4"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Vel ut dolor eaque maxime nihil necessitatibus sunt possimus.", new DateTime(2021, 4, 8, 11, 22, 29, 295, DateTimeKind.Local).AddTicks(8234) },
                    { new Guid("fdd76b7e-e165-4027-262d-96818275c216"), 66.637m, new Guid("de162a4f-d27d-413c-a6ea-b42ef892b7b4"), new Guid("5d145158-07e9-e0b9-3823-70eb5a3f6b04"), "Ut laboriosam fugiat atque neque illum quasi voluptatum molestias.", new DateTime(2021, 4, 8, 13, 17, 43, 58, DateTimeKind.Local).AddTicks(412) },
                    { new Guid("db84975a-d9eb-1680-2705-1b7f54d977a9"), 105.452m, new Guid("de162a4f-d27d-413c-a6ea-b42ef892b7b4"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Natus et et magnam perspiciatis reprehenderit.", new DateTime(2021, 4, 8, 6, 34, 49, 309, DateTimeKind.Local).AddTicks(424) },
                    { new Guid("e9cb4caa-d76f-81e3-c41a-5c6d4f422ca7"), 165.783m, new Guid("de162a4f-d27d-413c-a6ea-b42ef892b7b4"), new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), "Quo beatae mollitia unde ut natus cumque et.", new DateTime(2021, 4, 8, 6, 4, 8, 60, DateTimeKind.Local).AddTicks(1637) },
                    { new Guid("20d92006-254f-622b-f2ef-8a57375a3bc4"), 77.466m, new Guid("e1bd594f-94e3-a483-7af1-d1fc945a9ee2"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Itaque voluptatum fuga a illo hic earum.", new DateTime(2021, 4, 8, 17, 31, 46, 365, DateTimeKind.Local).AddTicks(993) },
                    { new Guid("e71e8526-79fb-877c-e5f4-7dbc746d8f9a"), 213.072m, new Guid("e1bd594f-94e3-a483-7af1-d1fc945a9ee2"), new Guid("ec65c208-2729-c1e9-d523-a898c5b77652"), "Voluptas consequatur qui eveniet mollitia deserunt ipsum consequatur.", new DateTime(2021, 4, 8, 9, 6, 7, 613, DateTimeKind.Local).AddTicks(2863) },
                    { new Guid("4d1f01ff-4e6b-e1aa-9851-e711d686d0b4"), 32.968m, new Guid("e1bd594f-94e3-a483-7af1-d1fc945a9ee2"), new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), "Occaecati eos ut aliquid dolorem dolores et odio quas ut.", new DateTime(2021, 4, 8, 17, 54, 5, 873, DateTimeKind.Local).AddTicks(2572) },
                    { new Guid("77c27c74-1a72-7afa-9cd5-5042289e0cbe"), 151.049m, new Guid("e1bd594f-94e3-a483-7af1-d1fc945a9ee2"), new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), "Officia voluptatibus nobis molestias velit voluptas sed.", new DateTime(2021, 4, 8, 0, 52, 32, 209, DateTimeKind.Local).AddTicks(2263) },
                    { new Guid("1f7e077d-401d-684e-4b56-14135f83f180"), 47.356m, new Guid("909af969-c847-b9db-a482-dd3affbcb403"), new Guid("dd7862d0-30a3-4309-2831-abb202451eb0"), "Quidem et non et in voluptatem consequatur et ad accusantium.", new DateTime(2021, 4, 7, 23, 46, 56, 714, DateTimeKind.Local).AddTicks(4533) },
                    { new Guid("08b61905-f644-beb2-389e-1143bf3bd986"), 7.992m, new Guid("74db33d2-a975-9a10-bb6a-12f56f44aaaf"), new Guid("844cf98c-f205-b7fb-0489-4ed02fb78ef2"), "Sint ea itaque ut et aspernatur exercitationem soluta et enim.", new DateTime(2021, 4, 8, 5, 31, 42, 303, DateTimeKind.Local).AddTicks(8404) },
                    { new Guid("eb5a6224-4ba0-ddb5-aab4-6288bbbf2f4f"), 11.800m, new Guid("74db33d2-a975-9a10-bb6a-12f56f44aaaf"), new Guid("bfd0364f-2aff-91b8-78fa-9516736e28e9"), "Ipsum esse suscipit voluptas quas tempore.", new DateTime(2021, 4, 8, 1, 28, 6, 483, DateTimeKind.Local).AddTicks(9389) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_UserId",
                table: "Asset",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AssetId",
                table: "Transaction",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CategoryId",
                table: "Transaction",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
