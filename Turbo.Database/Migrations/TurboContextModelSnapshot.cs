﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Turbo.Database.Context;

namespace Turbo.Database.Migrations
{
    [DbContext(typeof(TurboContext))]
    partial class TurboContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Turbo.Database.Entities.Furniture.FurnitureDefinitionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("CanGroup")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_group");

                    b.Property<bool>("CanLay")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_lay");

                    b.Property<bool>("CanRecycle")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_recycle");

                    b.Property<bool>("CanSell")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_sell");

                    b.Property<bool>("CanSit")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_sit");

                    b.Property<bool>("CanStack")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_stack");

                    b.Property<bool>("CanTrade")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_trade");

                    b.Property<bool>("CanWalk")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_walk");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<string>("ExtraData")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("extra_data");

                    b.Property<string>("Logic")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("logic");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("product_name");

                    b.Property<string>("PublicName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("public_name");

                    b.Property<int>("SpriteId")
                        .HasColumnType("int")
                        .HasColumnName("sprite_id");

                    b.Property<int>("TotalStates")
                        .HasColumnType("int")
                        .HasColumnName("total_states");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("type");

                    b.Property<int>("UsagePolicy")
                        .HasColumnType("int")
                        .HasColumnName("usage_policy");

                    b.Property<int>("X")
                        .HasColumnType("int")
                        .HasColumnName("x");

                    b.Property<int>("Y")
                        .HasColumnType("int")
                        .HasColumnName("y");

                    b.Property<double>("Z")
                        .HasColumnType("double")
                        .HasColumnName("z");

                    b.HasKey("Id");

                    b.ToTable("furniture_definitions");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Furniture.FurnitureEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<int>("FurnitureDefinitionEntityId")
                        .HasColumnType("int")
                        .HasColumnName("definition_id");

                    b.Property<int>("PlayerEntityId")
                        .HasColumnType("int")
                        .HasColumnName("player_id");

                    b.Property<int?>("RoomEntityId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.Property<int>("Rotation")
                        .HasColumnType("int")
                        .HasColumnName("direction");

                    b.Property<string>("StuffData")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("stuff_data");

                    b.Property<string>("WallPosition")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("wall_position");

                    b.Property<int>("X")
                        .HasColumnType("int")
                        .HasColumnName("x");

                    b.Property<int>("Y")
                        .HasColumnType("int")
                        .HasColumnName("y");

                    b.Property<double>("Z")
                        .HasColumnType("double")
                        .HasColumnName("z");

                    b.HasKey("Id");

                    b.HasIndex("FurnitureDefinitionEntityId");

                    b.HasIndex("PlayerEntityId");

                    b.HasIndex("RoomEntityId");

                    b.ToTable("furniture");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Navigator.NavigatorEventCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<bool>("Enabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("navigator_event_categories");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Players.PlayerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<string>("Figure")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("figure");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("gender");

                    b.Property<string>("Motto")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("motto");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("players");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomBanEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<int>("PlayerEntityId")
                        .HasColumnType("int")
                        .HasColumnName("player_id");

                    b.Property<int>("RoomEntityId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.HasKey("Id");

                    b.HasIndex("PlayerEntityId");

                    b.HasIndex("RoomEntityId");

                    b.ToTable("room_bans");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("AllowEditing")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("allow_editing");

                    b.Property<bool>("AllowPets")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("allow_pets");

                    b.Property<bool>("AllowPetsEat")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("allow_pets_eat");

                    b.Property<bool>("AllowWalkThrough")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("allow_walk_through");

                    b.Property<int>("BanType")
                        .HasColumnType("int")
                        .HasColumnName("ban_type");

                    b.Property<int>("ChatDistance")
                        .HasColumnType("int")
                        .HasColumnName("chat_distance");

                    b.Property<int>("ChatModeType")
                        .HasColumnType("int")
                        .HasColumnName("chat_mode_type");

                    b.Property<int>("ChatProtectionType")
                        .HasColumnType("int")
                        .HasColumnName("chat_protection_type");

                    b.Property<int>("ChatSpeedType")
                        .HasColumnType("int")
                        .HasColumnName("chat_speed_type");

                    b.Property<int>("ChatWeightType")
                        .HasColumnType("int")
                        .HasColumnName("chat_weight_type");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("description");

                    b.Property<bool>("HideWalls")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("hide_walls");

                    b.Property<int>("KickType")
                        .HasColumnType("int")
                        .HasColumnName("kick_type");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("last_active");

                    b.Property<int>("MuteType")
                        .HasColumnType("int")
                        .HasColumnName("mute_type");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("name");

                    b.Property<double>("PaintFloor")
                        .HasColumnType("double")
                        .HasColumnName("paint_floor");

                    b.Property<double>("PaintLandscape")
                        .HasColumnType("double")
                        .HasColumnName("paint_landscape");

                    b.Property<double>("PaintWall")
                        .HasColumnType("double")
                        .HasColumnName("paint_wall");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("password");

                    b.Property<int>("PlayerEntityId")
                        .HasColumnType("int")
                        .HasColumnName("player_id");

                    b.Property<int>("RoomModelEntityId")
                        .HasColumnType("int")
                        .HasColumnName("model_id");

                    b.Property<int>("RoomState")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<int>("ThicknessFloor")
                        .HasColumnType("int")
                        .HasColumnName("thickness_floor");

                    b.Property<int>("ThicknessWall")
                        .HasColumnType("int")
                        .HasColumnName("thickness_wall");

                    b.Property<int>("TradeType")
                        .HasColumnType("int")
                        .HasColumnName("trade_type");

                    b.Property<int>("UsersMax")
                        .HasColumnType("int")
                        .HasColumnName("users_max");

                    b.Property<int>("UsersNow")
                        .HasColumnType("int")
                        .HasColumnName("users_now");

                    b.Property<int>("WallHeight")
                        .HasColumnType("int")
                        .HasColumnName("wall_height");

                    b.HasKey("Id");

                    b.HasIndex("PlayerEntityId");

                    b.HasIndex("RoomModelEntityId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomModelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Custom")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("custom");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<int>("DoorRotation")
                        .HasColumnType("int")
                        .HasColumnName("door_rotation");

                    b.Property<int>("DoorX")
                        .HasColumnType("int")
                        .HasColumnName("door_x");

                    b.Property<int>("DoorY")
                        .HasColumnType("int")
                        .HasColumnName("door_y");

                    b.Property<bool>("Enabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("enabled");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("room_models");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomMuteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<int>("PlayerEntityId")
                        .HasColumnType("int")
                        .HasColumnName("player_id");

                    b.Property<int>("RoomEntityId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.HasKey("Id");

                    b.HasIndex("PlayerEntityId");

                    b.HasIndex("RoomEntityId");

                    b.ToTable("room_mutes");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomRightEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<int>("PlayerEntityId")
                        .HasColumnType("int")
                        .HasColumnName("player_id");

                    b.Property<int>("RoomEntityId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.HasKey("Id");

                    b.HasIndex("PlayerEntityId");

                    b.HasIndex("RoomEntityId");

                    b.ToTable("room_rights");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Security.SecurityTicketEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_updated");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("ip_address");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_locked");

                    b.Property<int>("PlayerEntityId")
                        .HasColumnType("int")
                        .HasColumnName("player_id");

                    b.Property<string>("Ticket")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("ticket");

                    b.HasKey("Id");

                    b.HasIndex("PlayerEntityId");

                    b.ToTable("security_tickets");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Furniture.FurnitureEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Furniture.FurnitureDefinitionEntity", "FurnitureDefinitionEntity")
                        .WithMany("Furnitures")
                        .HasForeignKey("FurnitureDefinitionEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turbo.Database.Entities.Players.PlayerEntity", "PlayerEntity")
                        .WithMany()
                        .HasForeignKey("PlayerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turbo.Database.Entities.Room.RoomEntity", "RoomEntity")
                        .WithMany()
                        .HasForeignKey("RoomEntityId");

                    b.Navigation("FurnitureDefinitionEntity");

                    b.Navigation("PlayerEntity");

                    b.Navigation("RoomEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomBanEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Players.PlayerEntity", "PlayerEntity")
                        .WithMany()
                        .HasForeignKey("PlayerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turbo.Database.Entities.Room.RoomEntity", "RoomEntity")
                        .WithMany("RoomBans")
                        .HasForeignKey("RoomEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerEntity");

                    b.Navigation("RoomEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Players.PlayerEntity", "PlayerEntity")
                        .WithMany()
                        .HasForeignKey("PlayerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turbo.Database.Entities.Room.RoomModelEntity", "RoomModelEntity")
                        .WithMany()
                        .HasForeignKey("RoomModelEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerEntity");

                    b.Navigation("RoomModelEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomMuteEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Players.PlayerEntity", "PlayerEntity")
                        .WithMany()
                        .HasForeignKey("PlayerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turbo.Database.Entities.Room.RoomEntity", "RoomEntity")
                        .WithMany("RoomMutes")
                        .HasForeignKey("RoomEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerEntity");

                    b.Navigation("RoomEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomRightEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Players.PlayerEntity", "PlayerEntity")
                        .WithMany()
                        .HasForeignKey("PlayerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turbo.Database.Entities.Room.RoomEntity", "RoomEntity")
                        .WithMany("RoomRights")
                        .HasForeignKey("RoomEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerEntity");

                    b.Navigation("RoomEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Security.SecurityTicketEntity", b =>
                {
                    b.HasOne("Turbo.Database.Entities.Players.PlayerEntity", "PlayerEntity")
                        .WithMany("SecurityTickets")
                        .HasForeignKey("PlayerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerEntity");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Furniture.FurnitureDefinitionEntity", b =>
                {
                    b.Navigation("Furnitures");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Players.PlayerEntity", b =>
                {
                    b.Navigation("SecurityTickets");
                });

            modelBuilder.Entity("Turbo.Database.Entities.Room.RoomEntity", b =>
                {
                    b.Navigation("RoomBans");

                    b.Navigation("RoomMutes");

                    b.Navigation("RoomRights");
                });
#pragma warning restore 612, 618
        }
    }
}
