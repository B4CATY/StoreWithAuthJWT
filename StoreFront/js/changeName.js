async function editName(){
    const oldeUserName = localStorage.getItem("name");
    const token = localStorage.getItem("JWT_Access");
    
    const newUserName = document.querySelector("#typeNameX").value;
    
    document.querySelector("#typeNameX").value = "";

    const response = await fetch(`https://localhost:44380/api/Users/editname`, {
        method: 'PUT',
        headers: {
            "Accept": "application/json", 
            "Content-Type": "application/json",
            "Authorization": "Bearer " + token
        },
        body: JSON.stringify({
            oldUserName: oldeUserName,
            newUserName: newUserName
        })
    });
    //alert(+response.status);
    if (response.status == 200) {
        const data = await response.json();
        
        localStorage.setItem("name", data.newUserName);
        document.querySelector("#userNameId").innerHTML = iconUser + data.newUserName.toString();
        //location.href = '/';
        router.loadRoute('');
    }
    else if (response.status == 401){
        await refresh();
        
        await editName();
    } 
    else if (response.status == 400){
        const data = await response.json();
        
        createNameError(data.error.toString());
        
    }   
}

async function createNameError(error){
    document.querySelector("#error").innerHTML = `
    <label>
        <span
            style=" position: fixed; font-size: 75%; left: 404px;" 
            class="text-warning" >
            ${error}
        </span> 
        <br> 
    </label>
    `;
}