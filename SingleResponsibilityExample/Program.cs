using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Not Single Responsibility
            SendInviteNotSingleResponsibility sendNot = new SendInviteNotSingleResponsibility();
            sendNot.SendNot( "NotSingle@cffp.edu", "Not", "Single" );

            //Single Responsibility
            SendInviteAsSingleResponsibility sendAs = new SendInviteAsSingleResponsibility();
            sendAs.SendAs( "IsSingle@cffp.edu", "Is", "Single" );
        }

        public class SendInviteNotSingleResponsibility
        {
            public void SendNot( string email, string firstName, string lastName )
            {
                if ( String.IsNullOrWhiteSpace( firstName ) || String.IsNullOrWhiteSpace( lastName ) )
                {
                    throw new Exception( "Name is not valid!" );
                }

                if ( !email.Contains( "@" ) || !email.Contains( "." ) )
                {
                    throw new Exception( "Email is not valid!!" );
                }
            }

        }

        public class SendInviteAsSingleResponsibility
        {
            //Single Responsibility
            UserNameService UserNameService;
            EmailService EmailService;
            
            public SendInviteAsSingleResponsibility( UserNameService userNameService, EmailService emailService )
            {
                UserNameService = userNameService;
                EmailService = emailService;
            }

            public void SendAs( string email, string firstName, string lastName )
            {
                UserNameService.Validate( firstName, lastName );
                EmailService.Validate( email );

                Console.WriteLine( "Email: " + email );
                Console.WriteLine( "FirstName: " + firstName );
                Console.WriteLine( "LastName: " + lastName );
            }
        }
    }
}
