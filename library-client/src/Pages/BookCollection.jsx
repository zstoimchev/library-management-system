import React, {useState} from "react";
import {useSelector} from "react-redux";

const BookCollection = () => {
    const books = useSelector((state) => state.books.books);
    const authors = useSelector((state) => state.authors.authors);
    const [pageNumber, setPageNumber] = useState(1);

    return (<div className="container mt-4">
        <h2 className="text-center">Book Collection</h2>

        <table className="table table-striped table-bordered">
            <thead className="table-dark">
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Author</th>
                <th>Publication Year</th>
            </tr>
            </thead>
            <tbody>
            {books.map((book, index) => {
                const author = authors.find((a) => a.id === book.authorId);
                return (<tr key={book.id}>
                    <td>{index + 1}</td>
                    <td>{book.title}</td>
                    <td>{author ? author.name : "Unknown"}</td>
                    <td>{book.publicationYear}</td>
                </tr>)
            })}
            </tbody>
        </table>
        <div className="d-flex justify-content-center align-items-center mt-4">
            <button
                className="btn btn-primary mx-2" disabled={pageNumber === 1}
                onClick={() => setPageNumber((prev) => Math.max(prev - 1, 1))}>
                Prev
            </button>

            <span className="fs-5 mx-3">Page {pageNumber}</span>

            <button className="btn btn-primary mx-2"
                    onClick={() => setPageNumber((prev) => prev + 1)}>
                Next
            </button>
        </div>

    </div>);
};

export default BookCollection;
