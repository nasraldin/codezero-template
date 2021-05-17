#!/bin/bash
# Check out for generate self-signed certificates 
# https://docs.microsoft.com/en-us/dotnet/core/additional-tools/self-signed-certificates-guide
# https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl
# 
# Note
# The .aspnetcore 3.1 use .pfx and a password.
# .Net 5 Kestrel take .crt and PEM-encoded .key files.
# 
# by Nasr Aldin
# nasr2ldin@gmail.com
# https://github.com/nasraldin
# 

PARENT="api.dev"
openssl req \
-x509 \
-newkey rsa:4096 \
-sha256 \
-days 365 \
-nodes \
-keyout https/$PARENT.key \
-out https/$PARENT.crt \
-subj "/CN=${PARENT}" \
-extensions v3_ca \
-extensions v3_req \
-config <( \
  echo '[req]'; \
  echo 'default_bits= 4096'; \
  echo 'distinguished_name=req'; \
  echo 'x509_extension = v3_ca'; \
  echo 'req_extensions = v3_req'; \
  echo '[v3_req]'; \
  echo 'basicConstraints = CA:FALSE'; \
  echo 'keyUsage = nonRepudiation, digitalSignature, keyEncipherment'; \
  echo 'subjectAltName = @alt_names'; \
  echo '[ alt_names ]'; \
  echo "DNS.1 = www.${PARENT}"; \
  echo "DNS.2 = ${PARENT}"; \
  echo '[ v3_ca ]'; \
  echo 'subjectKeyIdentifier=hash'; \
  echo 'authorityKeyIdentifier=keyid:always,issuer'; \
  echo 'basicConstraints = critical, CA:TRUE, pathlen:0'; \
  echo 'keyUsage = critical, cRLSign, keyCertSign'; \
  echo 'extendedKeyUsage = serverAuth, clientAuth')

openssl x509 -noout -text -in https/$PARENT.crt

# To get a .pfx, uncomment the following command:
openssl pkcs12 -export -out https/$PARENT.pfx -inkey https/$PARENT.key -in https/$PARENT.crt -password pass:NasrAldin