namespace Models.Core
{
    public class TableVersion
    {
        public byte TableID { get; set; }

        public DatabaseTable Table
        {
            get { return (DatabaseTable)this.TableID; }
            set { this.TableID = (byte)value; }
        }

        public long Time { get; set; }
    }
}
