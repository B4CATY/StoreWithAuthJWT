async function createHeader(){
    await createDropDownCategories();
    await createUserHeader();
}
async function createUserHeader(){
    const name =  localStorage.getItem('name');
    const userHeaderHtml = document.querySelector("#userHeaderId");
    let admin = "";
    if(name == null){
        userHeaderHtml.innerHTML = signInAndSignUp;
    }
    else{
        //const name = "Igor";
        
        if(localStorage.getItem('role') == 'admin'){
            iconUser = `<i style="position:relative; top:-2px;" 
            class="fas fa-user-cog"></i>`
            admin = adddCartAndCategories;
            //<i class="fas fa-user-cog"></i>
            //<i class="fa-solid fa-user-gear"></i>
        }
        else{
            iconUser = `<i style="position:relative; top:-2px;"
             class="fa-solid fa-user"></i>`
        }

        userHeaderHtml.innerHTML = `<ul class="navbar-nav">
      
      
      <li class="nav-item dropdown dropdown-menu-dark" style="margin-left: auto;">
        <a class="nav-link bg-dark  dropdown-toggle d-flex align-items-center"
          
          role="button"
          data-mdb-toggle="dropdown"
          aria-expanded="false">
          <strong  id="userNameId" class="d-none d-sm-block ms-1">${iconUser}
          ${name}
          </strong>
          </a>
        
        <ul class="dropdown-menu bg-dark"
            style="position:fixed; top:57px; left:1722px;"
            aria-labelledby="navbarDropdownMenuLink">
            ${admin}
          <li>
            <a class="dropdown-item text-white" 
                onclick="router.loadRoute('editname')"
                role="button">Change UserName
                </a>
          </li>
          <li>
            <a class="dropdown-item text-white" 
                onclick="router.loadRoute('shoping-cart')"
                role="button">Shopping cart
                </a>
          </li>
          <li>
            <a class="dropdown-item text-white" 
            onclick="router.loadRoute('orders')"
            role="button">My orders
            </a>
          </li>
          <li>
            <a class="dropdown-item text-white"
            onclick="logout();" 
            role="button">Logout
            </a>
          </li>
        </ul>
      </li>
    </ul>`;
    }
}