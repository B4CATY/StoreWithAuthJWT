async function toSingIn()
{
    const email = document.getElementById("typeEmailX").value;
    const password = document.getElementById("typePasswordX").value;
    userSignIn = {
        email: email,
        password: password
    };

    document.getElementById("typeEmailX").value = "";
    document.getElementById("typePasswordX").value = "";

    await login(userSignIn);
}

async function login(user){
    // const userSignIn = {
    //         email: "TheBestUser1@gmail.com",
    //         password: "User_password1"
    //     };

    const response = await fetch("https://localhost:44380/api/Users/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            Email: user.email,
            password: user.password
        })
    });
    if (response.status == 200) {
        const data = await response.json();

        //console.log(data)
        //alert("success")
        localStorage.setItem("name", data.name);
        localStorage.setItem("email", data.email);
        localStorage.setItem("JWT_Access", data.acces);
        localStorage.setItem("JWT_Refresh", data.refresh);
        //alert("before getRole")
        await getRole();
        //alert("after getRole")
    }
    else if(response.status == 404) {
        const data = await response.json();
        createLoginError(data.error.toString());
        
    }
            

}

function createLoginError(error){
    document.querySelector("#error").innerHTML = `
    <label>
        <span
            style=" position: fixed; font-size: 75%; left: 738px;" 
            class="text-warning" >
            ${error}
        </span> 
        <br> 
    </label>
    `;
}