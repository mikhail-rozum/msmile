namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates DifficultyLevel table
    /// </summary>
    [Migration(202009192230, "Creates DifficultyLevel table")]
    public class AddDifficultyLevelTable : Migration
    {
        private const string TableName = "DifficultyLevel";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Complexity Levels")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable();
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
