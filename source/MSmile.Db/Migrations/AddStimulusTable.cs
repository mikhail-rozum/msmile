namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Add Stimulus table.
    /// </summary>
    [Migration(202012282237, "Add Stimulus table")]
    public class AddStimulusTable : Migration
    {
        private const string TableName = "Stimulus";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Stimulus for pupils")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("PupilId").AsInt64().NotNullable().ForeignKey("Pupil", "Id");
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
