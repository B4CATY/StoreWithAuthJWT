async function logout(){
    const response = await fetch("https://localhost:44380/api/Users/logout", {
        method: "DELETE",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            access_Token: localStorage.getItem("JWT_Access"),
            refresh_Token: localStorage.getItem("JWT_Refresh")
        })
    });
    if (response.status == 200 || response.status == 401) {

        // localStorage.removeItem("name");
        // localStorage.removeItem("email");
        // localStorage.removeItem('role');
        // localStorage.removeItem("JWT_Access");
        // localStorage.removeItem("JWT_Refresh");
        localStorage.clear();
        location.href = '/';
    }
}