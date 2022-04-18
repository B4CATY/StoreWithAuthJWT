async function pagination_start(id, name){
        const countPage = await GetCount(name);
        console.log(countPage + "sgdgfdgsfd");
        if(countPage < 3)
            return "";

        
        const cnt_page = Math.ceil(countPage / cnt); //кол-во страниц
        console.log(cnt_page)
        let page_start = 1;
        let page_end = cnt_page;
        if(cnt_page > 5){
            if(id > 3){
                if(id + 5 < cnt_page){
                    page_start = id -2;
                    page_end = id +2;
                }
                else{
                    page_start = cnt_page-5;
                    page_end = cnt_page;
                }
            }
        }   
       
        //выводим список страниц
        let paginator = document.querySelector(".pagination");
        let pages = "";
       
       
        for (let i = page_start-1; i < page_end; i++) {
            pages += `<li class="page-item"><a class="page-link bg-dark text-white-50 m-1" 
                style="border: 2px solid #32af00;" role="button"
                onclick="router.loadRoute('${name}', '${(i + 1)}')"
                id="page${(i + 1)}" ">
                ${(i + 1)} </a></li>`;
        }
        
        let page_previos = id != 1 ? `<li class="page-item">
                <a class="page-link bg-dark text-white-50 m-1"
                 style="border: 2px solid #32af00;" 
                 onclick="router.loadRoute('${name}', '${(+id-1)}')"
                 role="button" id="page-">Previous</a>
            </li>`
            : "";

        let page_next = id != cnt_page ?  `<li class="page-item">
                <a class="page-link bg-dark text-white-50 m-1"
                style="border: 2px solid #32af00;"
                onclick="router.loadRoute('${name}', '${(+id+1)}')"
                role="button" id="page+">Next</a>
            </li>`
             : "";
        paginator.innerHTML = page_previos + pages + page_next;

        main_page = document.getElementById(`page${id}`);
}




//листаем
// async function pagination(event) {
//     let e = event || window.event;
    
//     let target = e.target;
//     let id = target.id;
//   let num_ = id.substr(4);
//   console.log(num_);
//   if(pageNow != num_)
//   {
//     if(num_ == "-")
//     { 
//         if(pageNow > 1)
//             pageNow--;
//         else return;
//     }

//     else if(num_ == "+"){
//         let cnt = 2; //сколько отображаем сначала
//         let count = await GetVideoCartsCount();
//         let cnt_page = Math.ceil(count / cnt); //кол-во страниц
//         if(cnt_page > pageNow)
//             pageNow++;
//         else return;
//     } 
//     else pageNow = num_;
//     let newTab = await GetVideoCarts(pageNow)
//     if(newTab != null){
//         reset();
    
//         $('#videocartTableId').append(newTab);
//         pagination_start(pageNow);
//     }
   
//   }
  
// }
