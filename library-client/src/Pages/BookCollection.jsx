import React, {useEffect} from "react";
import {useDispatch, useSelector} from "react-redux";
import {fetchBooks} from "../Store/bookSlice";
import {fetchAuthors} from "../Store/authorSlice";

const BookCollection = () => {
    const dispatch = useDispatch();
    const books = useSelector((state) => state.books.books);
    const authors = useSelector((state) => state.authors.authors);
    const bookStatus = useSelector((state) => state.books.status);
    const authorStatus = useSelector((state) => state.authors.status);

    useEffect(() => {
        if (bookStatus === "idle") {
            dispatch(fetchBooks());
        }
        if (authorStatus === "idle") {
            dispatch(fetchAuthors());
        }
    }, [bookStatus, authorStatus, dispatch]);

    return (<div className="container mt-4">
        <h2 className="text-center">Book Collection</h2>

        {/*{status === "loading" && <p>Loading books...</p>}*/}
        {/*{status === "failed" && <p>Error loading books.</p>}*/}

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
    </div>);
};

export default BookCollection;
