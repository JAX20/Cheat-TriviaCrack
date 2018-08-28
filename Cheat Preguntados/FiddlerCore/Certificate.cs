using Fiddler;
using System;

namespace Cheat_Preguntados.FiddlerCore
{
    class Certificate
    {
        public static void Install()
        {
            /*
             * Find and create certificates for use in HTTPS interception
             */

            // Determine if the self signed root certificate exists
            if (!CertMaker.rootCertExists())
            {
                // Create a self signed root certificate to use as the trust anchor for HTTPS interception certificate chains
                if (!CertMaker.createRootCert())
                    throw new Exception("Unable to create certificate for FiddlerCore.");

                // Prompts the user to add it to the trusted store.
                if (!CertMaker.trustRootCert())
                    throw new Exception("Unable to create certificate for FiddlerCore.");
            }
        }

        public static bool Uninstall()
        {
            // Determine if the self signed root certificate exists
            if (CertMaker.rootCertExists())
            {
                // Removes Fiddler generated certificates. Parameter True for remove root
                if (!CertMaker.removeFiddlerGeneratedCerts(true))
                    return false;
            }
            return true;
        }
    }
}