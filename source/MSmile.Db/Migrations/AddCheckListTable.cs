namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Add CheckList table.
    /// </summary>
    [Migration(202012282216, "Add CheckList table")]
    public class AddCheckListTable : Migration
    {
        private const string TableName = "CheckList";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Check list")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("PupilId").AsInt64().NotNullable().ForeignKey("Pupil", "Id")
                .WithColumn("Created").AsDate().NotNullable()
                .WithColumn("Modified").AsDate().Nullable();
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
