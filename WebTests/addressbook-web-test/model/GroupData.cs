using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WebTests.model
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        [Column (Name = "group_name"), NotNull]
        public string Name { get; set; }
        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }
        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name  == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "\nname=" + Name + "\nheader= " + Header + "\nfooter= " + Footer;
        }

        public static List<GroupData> GetAll()
        {                
            using (AddressBookDB db = new AddressBookDB())
            {
                var x = (from g in db.Groups select g).ToList();
                return x;
            }
        }

        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                    from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated== "0000-00-00 00:00:00")
                    select c).Distinct().ToList();
            }
        }
    }
}
