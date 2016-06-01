using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rock.Plugin;
namespace com.centralaz.RoomManagement.Migrations
{
    [MigrationNumber( 1, "1.4.5" )]
    public class CreateDb : Migration
    {
        public override void Up()
        {
            Sql( @"
                CREATE TABLE [dbo].[_com_centralaz_RoomManagement_Reservation](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
                    [Name] [nvarchar](50) NULL,
	                [ScheduleId] [int] NOT NULL,
	                [CampusId] [int] NULL,
	                [MinistryId] [int] NULL,
	                [StatusId] [int] NULL,
                    [RequestorAliasId] [int] NULL,
	                [ApproverAliasId] [int] NULL,
	                [SetupTime] [int] NULL,
	                [CleanupTime] [int] NULL,
	                [NumberAttending] [int] NULL,
	                [IsApproved] [bit] NULL,
	                [Note] [nvarchar](50) NULL,
	                [Guid] [uniqueidentifier] NOT NULL,
	                [CreatedDateTime] [datetime] NULL,
	                [ModifiedDateTime] [datetime] NULL,
	                [CreatedByPersonAliasId] [int] NULL,
	                [ModifiedByPersonAliasId] [int] NULL,
	                [ForeignKey] [nvarchar](50) NULL,
                    [ForeignGuid] [uniqueidentifier] NULL,
                    [ForeignId] [int] NULL,
                 CONSTRAINT [PK__com_centralaz_RoomManagement_Reservation] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_Schedule] FOREIGN KEY([ScheduleId])
                REFERENCES [dbo].[Schedule] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_Schedule]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_Campus] FOREIGN KEY([CampusId])
                REFERENCES [dbo].[Campus] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_Campus]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_DefinedValue] FOREIGN KEY([MinistryId])
                REFERENCES [dbo].[DefinedValue] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_DefinedValue]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_DefinedValue1] FOREIGN KEY([StatusId])
                REFERENCES [dbo].[DefinedValue] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_DefinedValue1]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_PersonAlias] FOREIGN KEY([ApproverAliasId])
                REFERENCES [dbo].[PersonAlias] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_PersonAlias]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_PersonAlias1] FOREIGN KEY([RequestorAliasId])
                REFERENCES [dbo].[PersonAlias] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_PersonAlias1] 


                CREATE TABLE [dbo].[_com_centralaz_RoomManagement_Resource](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
                    [Name] [nvarchar](50) NULL,
	                [CategoryId] [int] NULL,
	                [CampusId] [int] NULL,
                    [Quantity] [int] NOT NULL,
	                [Note] [nvarchar](50) NULL,
	                [Guid] [uniqueidentifier] NOT NULL,
	                [CreatedDateTime] [datetime] NULL,
	                [ModifiedDateTime] [datetime] NULL,
	                [CreatedByPersonAliasId] [int] NULL,
	                [ModifiedByPersonAliasId] [int] NULL,
	                [ForeignKey] [nvarchar](50) NULL,
                    [ForeignGuid] [uniqueidentifier] NULL,
                    [ForeignId] [int] NULL,
                 CONSTRAINT [PK__com_centralaz_RoomManagement_Resource] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Resource]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_Resource_Category] FOREIGN KEY([CategoryId])
                REFERENCES [dbo].[Category] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Resource] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_Resource_Category]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Resource]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_Resource_Campus] FOREIGN KEY([CampusId])
                REFERENCES [dbo].[Campus] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Resource] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_Resource_Campus]


                CREATE TABLE [dbo].[_com_centralaz_RoomManagement_ReservationResource](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
	                [ReservationId] [int] NOT NULL,
	                [ResourceId] [int] NOT NULL,
                    [Quantity] [int] NOT NULL,
	                [IsApproved] [bit] NULL,
	                [Guid] [uniqueidentifier] NOT NULL,
	                [CreatedDateTime] [datetime] NULL,
	                [ModifiedDateTime] [datetime] NULL,
	                [CreatedByPersonAliasId] [int] NULL,
	                [ModifiedByPersonAliasId] [int] NULL,
	                [ForeignKey] [nvarchar](50) NULL,
                    [ForeignGuid] [uniqueidentifier] NULL,
                    [ForeignId] [int] NULL,
                 CONSTRAINT [PK__com_centralaz_RoomManagement_ReservationResource] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationResource]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationResource_Reservation] FOREIGN KEY([ReservationId])
                REFERENCES [dbo].[_com_centralaz_RoomManagement_Reservation] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationResource] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationResource_Reservation]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationResource]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationResource_Resource] FOREIGN KEY([ResourceId])
                REFERENCES [dbo].[_com_centralaz_RoomManagement_Resource] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationResource] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationResource_Resource]


                CREATE TABLE [dbo].[_com_centralaz_RoomManagement_ReservationLocation](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
	                [ReservationId] [int] NOT NULL,
	                [LocationId] [int] NOT NULL,
	                [IsApproved] [bit] NULL,
	                [Guid] [uniqueidentifier] NOT NULL,
	                [CreatedDateTime] [datetime] NULL,
	                [ModifiedDateTime] [datetime] NULL,
	                [CreatedByPersonAliasId] [int] NULL,
	                [ModifiedByPersonAliasId] [int] NULL,
	                [ForeignKey] [nvarchar](50) NULL,
                    [ForeignGuid] [uniqueidentifier] NULL,
                    [ForeignId] [int] NULL,
                 CONSTRAINT [PK__com_centralaz_RoomManagement_ReservationLocation] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationLocation]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationLocation_Reservation] FOREIGN KEY([ReservationId])
                REFERENCES [dbo].[_com_centralaz_RoomManagement_Reservation] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationLocation] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationLocation_Reservation]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationLocation]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationLocation_Location] FOREIGN KEY([LocationId])
                REFERENCES [dbo].[Location] ([Id])

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationLocation] CHECK CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationLocation_Location]
" );
            RockMigrationHelper.UpdateEntityType( "com.centralaz.RoomManagement.Model.Reservation", "839768A3-10D6-446C-A65B-B8F9EFD7808F", true, true );
            RockMigrationHelper.UpdateEntityType( "com.centralaz.RoomManagement.Model.ReservationLocation", "07084E96-2907-4741-80DF-016AB5981D12", true, true );
            RockMigrationHelper.UpdateEntityType( "com.centralaz.RoomManagement.Model.ReservationResource", "A9A1F735-0298-4137-BCC1-A9117B6543C9", true, true );
            RockMigrationHelper.UpdateEntityType( "com.centralaz.RoomManagement.Model.Resource", "35584736-8FE2-48DA-9121-3AFD07A2DA8D", true, true );
            RockMigrationHelper.AddDefinedType( "Global", "Ministry", "", "B6DC9824-FA8C-4B0F-AD82-F720F4FCFF24", @"" );
        }
        public override void Down()
        {
            RockMigrationHelper.DeleteDefinedType( "B6DC9824-FA8C-4B0F-AD82-F720F4FCFF24" ); // Ministry
            RockMigrationHelper.DeleteEntityType( "839768A3-10D6-446C-A65B-B8F9EFD7808F" );
            RockMigrationHelper.DeleteEntityType( "07084E96-2907-4741-80DF-016AB5981D12" );
            RockMigrationHelper.DeleteEntityType( "A9A1F735-0298-4137-BCC1-A9117B6543C9" );
            RockMigrationHelper.DeleteEntityType( "35584736-8FE2-48DA-9121-3AFD07A2DA8D" );

            Sql( @"
                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationLocation] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationLocation_Reservation]
                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationLocation] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationLocation_Location]
                DROP TABLE [dbo].[_com_centralaz_RoomManagement_ReservationLocation]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationResource] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationResource_Reservation]
                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_ReservationResource] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_ReservationResource_Resource]
                DROP TABLE [dbo].[_com_centralaz_RoomManagement_ReservationResource]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Resource] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_Resource_Campus]
                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Resource] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_Resource_Category]
                DROP TABLE [dbo].[_com_centralaz_RoomManagement_Resource]

                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_PersonAlias1]
                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_PersonAlias]
                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_DefinedValue1]
                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_DefinedValue]
                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_Campus]
                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Reservation] DROP CONSTRAINT [FK__com_centralaz_RoomManagement_Reservation_Schedule]
                DROP TABLE [dbo].[_com_centralaz_RoomManagement_Reservation]" );
        }
    }
}
