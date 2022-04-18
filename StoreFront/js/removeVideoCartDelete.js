async function removeVideocartDelete(){
    if(document.querySelector("#selectVideocart").value == null 
        || +document.querySelector("#selectVideocart").value < 1)
        return;

    const token = localStorage.getItem("JWT_Access");
    const videocartId = +document.querySelector("#selectVideocart").value;
    const url = `https://localhost:44315/admin/videocarts/${videocartId}`;
    const response = await fetch(url, {
        method: "DELETE",
        headers: 
        { 
            "Content-Type": "application/json",
            "Authorization": "Bearer " + token  
        },
        body: JSON.stringify({
            id: videocartId
        })
    });
    if (response.status == 204) {
        //alert("success");
        router.loadRoute('');
    }
    else if (response.status == 401){
         let result = await refresh();
        if(result == 200)
            await removeVideocartDelete();
    }
    else if (response.status == 405){
        await logout();
    }
    else if (response.status == 404) {
        document.querySelector("#error").innerHTML = createLoginError("Not fount category").toString();
    }
}