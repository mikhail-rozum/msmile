namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Remove PupilId from Lesson table.
    /// </summary>
    [Migration(202012282227, "Remove PupilId from Lesson table")]
    public class RemovePupilIdFromLessonTable : Migration
    {
        private const string TableName = "Lesson";

        /// <inheritdoc />
        public override void Up()
        {
            this.Delete.Column("PupilId").FromTable(TableName);
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
