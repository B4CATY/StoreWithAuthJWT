
async function getRole(){

    const token = localStorage.getItem("JWT_Access");
    console.log(token);
    const url = `https://localhost:44380/api/users/role`;
    const response = await fetch(url, {
        method: "GET",
        headers: {
            "Authorization": "Bearer " + token  // передача токена в заголовке
        },
        
    });
    ///
    //alert(response.status);
    if (response.status == 200) {
        localStorage.setItem('role', `admin`);
        location.href = '/';
    }

    else if(response.status == 405 || response.status == 403){
        localStorage.setItem('role', `user`);
        location.href = '/';
    }
    else{
        await logout();
    }
}