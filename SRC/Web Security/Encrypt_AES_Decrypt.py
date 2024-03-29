import base64
from Crypto.Cipher import AES
from Crypto import Random
import os

key = os.urandom(AES.block_size*2)
BS = AES.block_size
pad = lambda s: s + (BS - len(s) % BS) * chr(BS - len(s) % BS) 
unpad = lambda s : s[:-ord(s[len(s)-1:])]
def encrypt(raw):
    raw = pad(raw)
    iv = Random.new().read( AES.block_size )
    cipher = AES.new(key, AES.MODE_CBC, iv )
    return base64.b64encode( iv + cipher.encrypt( raw ) ) 

def decrypt(enc):
    enc = base64.b64decode(enc)
    iv = enc[:16]
    cipher = AES.new(key, AES.MODE_CBC, iv )
    return unpad(cipher.decrypt( enc[16:] ))

f= open('image.jpg')
plain = f.read()
cipher = encrypt(plain)

fOut = open('encrypted','w')
fOut.write(cipher)
fOut.close()

f= open('encrypted')
cipher = f.read()
decrypted = open('decrypted', 'w')
decrypted.write(decrypt(cipher))
decrypted.close()

## ALT with TEXT data example for pycryptodome with a base64-encoded message using an OpenPGP mode block cipher. 
## (OpenPGP stores the encrypted IV (initialization vector) into the first 18 bytes of the encrypted message) 

import base64
from Crypto.Cipher import AES

input_data = b'I am a secret message'
key = b'Sixteen byte key'

## ENCRYPTION

encryption_cipher = AES.new(key, AES.MODE_OPENPGP)

# use a nonce, e.g when the mode is AES.MODE_EAX
#nonce = encryption_cipher.nonce
ciphertext = encryption_cipher.encrypt(input_data)  

b64_ciphertext = base64.b64encode(ciphertext).decode()
print("Base64 of AES-encrypted message: ", b64_ciphertext)

## DECRYPTION

unb64_ciphertext = base64.b64decode(b64_ciphertext.encode())
iv = unb64_ciphertext[0:18]
unb64_ciphertext = unb64_ciphertext[18:]

decryption_cipher = AES.new(key, AES.MODE_OPENPGP, iv=iv)#, nonce=nonce)
output_data = decryption_cipher.decrypt(unb64_ciphertext)

print("Decrypted message: ", output_data)
