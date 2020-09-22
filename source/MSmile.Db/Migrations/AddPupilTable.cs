namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates Pupil table
    /// </summary>
    [Migration(202009191512, "Creates Pupil table")]
    public class AddPupilTable : Migration
    {
        private const string TableName = "Pupil";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Pupils")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(50).NotNullable()
                .WithColumn("MiddleName").AsString(50).NotNullable()
                .WithColumn("LastName").AsString(50).NotNullable()
                .WithColumn("BirthDate").AsDate().NotNullable()
                .WithColumn("Comment").AsString(1000).Nullable();
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
