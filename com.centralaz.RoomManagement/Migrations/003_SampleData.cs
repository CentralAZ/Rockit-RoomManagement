using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rock.Plugin;
namespace com.centralaz.RoomManagement.Migrations
{
    [MigrationNumber( 3, "1.4.5" )]
    public class SampleData : Migration
    {
        public override void Up()
        {
            Sql( @"INSERT [dbo].[Category] ( [IsSystem], [ParentCategoryId], [EntityTypeId], [EntityTypeQualifierColumn], [EntityTypeQualifierValue], [Name], [IconCssClass], [Guid], [Order], [Description], [CreatedDateTime], [ModifiedDateTime], [CreatedByPersonAliasId], [ModifiedByPersonAliasId], [ForeignKey], [HighlightColor], [ForeignGuid], [ForeignId]) VALUES ( 0, NULL, 262, NULL, NULL, N'Vehicles', N'', N'ae3f4a8d-46d7-4520-934c-85d80167b22c', 0, N'', CAST(N'2016-06-08 09:03:33.357' AS DateTime), CAST(N'2016-06-08 09:03:33.357' AS DateTime), 10, 10, NULL, N'', NULL, NULL)
                    INSERT [dbo].[Category] ( [IsSystem], [ParentCategoryId], [EntityTypeId], [EntityTypeQualifierColumn], [EntityTypeQualifierValue], [Name], [IconCssClass], [Guid], [Order], [Description], [CreatedDateTime], [ModifiedDateTime], [CreatedByPersonAliasId], [ModifiedByPersonAliasId], [ForeignKey], [HighlightColor], [ForeignGuid], [ForeignId]) VALUES ( 0, NULL, 262, NULL, NULL, N'Tables', N'', N'baf88943-64ea-4a6a-8e1e-f4efc5a6ceca', 1, N'', CAST(N'2016-06-08 09:03:37.957' AS DateTime), CAST(N'2016-06-08 09:03:37.957' AS DateTime), 10, 10, NULL, N'', NULL, NULL)
                    INSERT [dbo].[Category] ( [IsSystem], [ParentCategoryId], [EntityTypeId], [EntityTypeQualifierColumn], [EntityTypeQualifierValue], [Name], [IconCssClass], [Guid], [Order], [Description], [CreatedDateTime], [ModifiedDateTime], [CreatedByPersonAliasId], [ModifiedByPersonAliasId], [ForeignKey], [HighlightColor], [ForeignGuid], [ForeignId]) VALUES ( 0, NULL, 262, NULL, NULL, N'Projectors', N'', N'd29a2afc-bd90-428b-9065-2ffd09fb6f6b', 2, N'', CAST(N'2016-06-08 09:03:43.350' AS DateTime), CAST(N'2016-06-08 09:03:43.350' AS DateTime), 10, 10, NULL, N'', NULL, NULL)
                    INSERT [dbo].[Category] ( [IsSystem], [ParentCategoryId], [EntityTypeId], [EntityTypeQualifierColumn], [EntityTypeQualifierValue], [Name], [IconCssClass], [Guid], [Order], [Description], [CreatedDateTime], [ModifiedDateTime], [CreatedByPersonAliasId], [ModifiedByPersonAliasId], [ForeignKey], [HighlightColor], [ForeignGuid], [ForeignId]) VALUES ( 0, NULL, 262, NULL, NULL, N'Chairs', N'', N'355ac2fd-0831-4a11-9294-5568fdfa8fc3', 3, N'', CAST(N'2016-06-08 09:03:48.073' AS DateTime), CAST(N'2016-06-08 09:03:48.073' AS DateTime), 10, 10, NULL, N'', NULL, NULL)
                    INSERT [dbo].[Category] ( [IsSystem], [ParentCategoryId], [EntityTypeId], [EntityTypeQualifierColumn], [EntityTypeQualifierValue], [Name], [IconCssClass], [Guid], [Order], [Description], [CreatedDateTime], [ModifiedDateTime], [CreatedByPersonAliasId], [ModifiedByPersonAliasId], [ForeignKey], [HighlightColor], [ForeignGuid], [ForeignId]) VALUES ( 0, NULL, 262, NULL, NULL, N'Other', N'', N'ddede1a7-c02b-4322-9d5b-a73cdb9224c6', 4, N'', CAST(N'2016-06-08 09:03:52.830' AS DateTime), CAST(N'2016-06-08 09:03:52.830' AS DateTime), 10, 10, NULL, N'', NULL, NULL)
                    INSERT [dbo].[_com_centralaz_RoomManagement_Resource] ( [Name], [CategoryId], [CampusId], [Quantity], [Note], [Guid], [CreatedDateTime], [ModifiedDateTime], [CreatedByPersonAliasId], [ModifiedByPersonAliasId], [ForeignKey], [ForeignGuid], [ForeignId]) VALUES ( N'Van 14', 179, 1, 1, N'', N'18245995-0847-4a76-a86e-6bd02b4b49a3', CAST(N'2016-06-08 09:04:13.653' AS DateTime), CAST(N'2016-06-08 09:04:13.653' AS DateTime), 10, 10, NULL, NULL, NULL)
                    INSERT [dbo].[_com_centralaz_RoomManagement_Resource] ( [Name], [CategoryId], [CampusId], [Quantity], [Note], [Guid], [CreatedDateTime], [ModifiedDateTime], [CreatedByPersonAliasId], [ModifiedByPersonAliasId], [ForeignKey], [ForeignGuid], [ForeignId]) VALUES ( N'Baptism Tub', 183, 1, 1, N'', N'483cc882-6bf0-4e0c-b773-138df685c7df', CAST(N'2016-06-08 09:04:26.420' AS DateTime), CAST(N'2016-06-08 09:04:26.420' AS DateTime), 10, 10, NULL, NULL, NULL)
                    INSERT [dbo].[_com_centralaz_RoomManagement_Resource] ( [Name], [CategoryId], [CampusId], [Quantity], [Note], [Guid], [CreatedDateTime], [ModifiedDateTime], [CreatedByPersonAliasId], [ModifiedByPersonAliasId], [ForeignKey], [ForeignGuid], [ForeignId]) VALUES ( N'Lobby Tables', 180, 1, 12, N'', N'0180e05c-8dbb-44fc-875e-435a81bd994c', CAST(N'2016-06-08 09:04:38.640' AS DateTime), CAST(N'2016-06-08 09:04:38.640' AS DateTime), 10, 10, NULL, NULL, NULL)
                    INSERT [dbo].[_com_centralaz_RoomManagement_Resource] ( [Name], [CategoryId], [CampusId], [Quantity], [Note], [Guid], [CreatedDateTime], [ModifiedDateTime], [CreatedByPersonAliasId], [ModifiedByPersonAliasId], [ForeignKey], [ForeignGuid], [ForeignId]) VALUES ( N'Children''s Portable Projector', 181, 1, 1, N'', N'9b82ce62-36db-4f62-8b51-24b140496a00', CAST(N'2016-06-08 09:04:56.143' AS DateTime), CAST(N'2016-06-08 09:04:56.143' AS DateTime), 10, 10, NULL, NULL, NULL)
                    INSERT [dbo].[_com_centralaz_RoomManagement_Resource] ( [Name], [CategoryId], [CampusId], [Quantity], [Note], [Guid], [CreatedDateTime], [ModifiedDateTime], [CreatedByPersonAliasId], [ModifiedByPersonAliasId], [ForeignKey], [ForeignGuid], [ForeignId]) VALUES ( N'Gym Chairs', 182, 1, 140, N'', N'b3aff3ac-762b-4d45-800d-08195bd5b849', CAST(N'2016-06-08 09:05:09.053' AS DateTime), CAST(N'2016-06-08 09:05:09.053' AS DateTime), 10, 10, NULL, NULL, NULL)
                    " );
        }
        public override void Down()
        {
        }
    }
}
