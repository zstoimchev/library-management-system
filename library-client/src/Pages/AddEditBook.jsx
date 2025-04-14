import React from "react";

const AddEditBook = () => {
    return (
        <div className="container mt-4">
            <h2 className="text-center">Add New Book</h2>
            <form className="p-4 bg-light rounded shadow">
                <div className="mb-3">
                    <label htmlFor="bookName" className="form-label">Name of the Book</label>
                    <input type="text" className="form-control" id="bookName" placeholder="Enter book name" />
                </div>

                <div className="mb-3">
                    <label htmlFor="publicationYear" className="form-label">Publication Year</label>
                    <input type="number" className="form-control" id="publicationYear" placeholder="Enter publication year" />
                </div>

                <div className="mb-3">
                    <label htmlFor="authorSelect" className="form-label">Author of the Book</label>
                    <select className="form-select" id="authorSelect">
                        <option value="">Select an author</option>
                        <option value="1">Author 1</option>
                        <option value="2">Author 2</option>
                        <option value="3">Author 3</option>
                        <option value="4">Author 4</option>
                        <option value="5">Author 5</option>
                    </select>
                </div>

                <button type="submit" className="btn btn-primary w-100">Submit</button>
            </form>
        </div>
    );
};

export default AddEditBook;
