const vTableStart = `
<div style="position:relative; top: 100px; margin-bottom:100px;">
      <div style="position: relative; left: 60px; width: 1200px;">
        <table class="table table-borderless bg-dark text-white-50">
          <thead>
            <tr>
              <th style="width:0px;"></th>
              <th ></th>
              <th class="text-center">Name</th>
              <th class="text-center">Category</th>
              <th class="text-center">Price</th>
              <th></th>
            </tr>
          </thead>
          <tbody id="videocartTableId">
          `;

  const vTableEnd =  `
  </tbody>
          </table>
          
      </div>
    
        
    
  
  

`;
const paginationHtml = `<nav aria-label="Page navigation example">
<ul class="pagination justify-content-md-center">
</ul>
</nav>`;

const divEnd = `</div>`;
// onclick="pagination(event)"