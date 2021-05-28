#!/bin/bash
# Adding trusted root certificates to the server Mac OS X
# https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl
# 
# by Nasr Aldin
# nasr2ldin@gmail.com
# https://github.com/nasraldin
# 

sudo security add-trusted-cert -d -r trustRoot -k /Library/Keychains/System.keychain https/api.dev.crt

# to delete certificate use the following command
# sudo security delete-certificate -c "<name of existing certificate>"