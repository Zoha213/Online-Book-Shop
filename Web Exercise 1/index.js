
$(document).ready(function () {
  let books = [];
  let currentPage = 1;
  const books_per_page = 3; //limits on 1 page

  // Function to fetch books from JSON and display them
  function fetchBooks(current_page, books_limit) {
    $.ajax({
      url: "http://localhost:5000/api/Books",
      method: "GET",
      success: function (data) {
        let i = (current_page - 1) * books_limit; //i is the variable for the starting point of the array
        let j = i + books_limit; //j is for the ending point of array
        let booksToShow = data.slice(i, j); //copy of array

        if (booksToShow.length > 0) {
          books = books.concat(booksToShow); //books[] = booksToShow[0]+booksToShow[1]....
          display(books);
        }
      },
    });
  }

  // Initial load
  fetchBooks(currentPage, books_per_page);

  $("#searchBar").on("input", function () {
    let query = $(this).val().trim().toLowerCase(); //for any style of input convert in lower
    if (query === "") {
      display(books);
    } else {
      let fetched_data = books.filter(
        (book) =>
          (book.title.toLowerCase() &&
            book.title.toLowerCase().includes(query)) ||
          (book.author.toLowerCase() &&
            book.author.toLowerCase().includes(query))
      );
      $("#output_data").empty();
      display(fetched_data);
    }
  });

  $("#more_options").on("click", function () {
    currentPage++;
    fetchBooks(currentPage, books_per_page);
  });

  function display(books) {
    $("#output_data", function () {
      let out;
      for (let i = 0; i < books.length; i++) {
        //var book = data[i];
        out += `
                <tr>
                <td>${books[i].title}</td>
                <td>${books[i].author}</td>
                <td>${books[i].description}</td>
                <td><img src="${books[i].image}" alt="book" width="100px" height="100px"></td>
                </tr>
                `;
      }
      $("#output_data").html(out);
    });
  };

  $("#addBookForm").on("submit", function (event) {
    event.preventDefault();

    const newBook = {
      title: $("#title").val(),
      author: $("#author").val(),
      description: $("#description").val(),
      image: $("#image").val(),
    };

    $.ajax({
      url: "http://localhost:5000/api/Books",
      method: "POST",
      contentType: "application/json",
      data: JSON.stringify(newBook),
      success: function (data) {
        books.push(data); // Add the new book to the list
        display(books); // Update the display
        $("#addBookForm")[0].reset(); // Reset the form
      },
      error: function (xhr, status, error) {
        alert("Error: " + xhr.responseText);
      },
    });
  });

  // function openform() {
  //   $("#form").style.display = "block";
  // }

  // function closeform() {
  //   $("#form").style.display = "none";
  // }
});
