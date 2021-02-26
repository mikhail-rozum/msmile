namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Rename Task table to Exercise.
    /// </summary>
    [Migration(202012262049, "Rename Task table to exercise")]
    public class RenameTaskTable : Migration
    {
        private const string SchemaName = "public";
        private const string OldTableName = "Task";
        private const string NewTableName = "Exercise";

        /// <inheritdoc />
        public override void Up()
        {
            this.Rename.Table(OldTableName).InSchema(SchemaName).To(NewTableName);
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
