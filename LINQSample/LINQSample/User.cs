using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSample
{
    class User : IEquatable<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals( object rhs )
        {
            if ( ReferenceEquals( this, null ) )
                return false;

            if ( ReferenceEquals( this, rhs ) )
                return true;

            if ( this.GetType() != rhs.GetType() )
                return false;

            return base.Equals( rhs );
        }

        public bool Equals( User rhs )
        {
            return ( Id == rhs.Id ) &&
                   ( Name == rhs.Name ) &&
                   ( Age == rhs.Age );
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
