Online store on with authorization using JWT.
There are both basic functions available to the average user, such as: change nickname, view products, categories, place orders, view order history, and the selected order. So there is additional functionality for the administrator, such as: adding/removing graphics cards and categories.
Viewing video cards is arranged with the help of pagination.

STARTUP GUIDE

First run StoreBackEnd and RefreshJWTToken

Then go to the StoreFront folder and run vsCode in it and in PowerShell run 2 commands:

npm install http-server-spa -g

Go to the Index.html file and type the second command

http-server-spa . ./index.html

Enjoy the project!
