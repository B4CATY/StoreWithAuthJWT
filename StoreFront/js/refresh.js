async function refresh(){
    const token_acces = localStorage.getItem("JWT_Access");
    const token_refresh = localStorage.getItem("JWT_Refresh");

    const response = await fetch(`https://localhost:44380/api/users/refresh`, {
        method: 'POST',
        headers: {
            "Accept": "application/json", 
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            Access_Token: token_acces,
            Refresh_Token: token_refresh
        })
    });
    if (response.status == 200) {
       const token = await response.json()
       localStorage.setItem("JWT_Access", token.acces)
       localStorage.setItem("JWT_Refresh", token.refresh)
        return 200;
       //alert("succes refresh");
    }
    else if (response.status == 400){
       await logout();
    }   
}