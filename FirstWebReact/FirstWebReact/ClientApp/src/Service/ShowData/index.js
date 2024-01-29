import { useEffect, useState } from "react";

const ShowDataUser = () => {
    const [users, setuser] = useState([])

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('api/User/GetUsers');
                const data = await response.json();
                setuser(data);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, []);
    return (
        <div className="container">
            <h1>User</h1>
            <div className="row">
                <div className="col-sm-12">
                    <table className="table table-striped">
                        <thead>

                            <tr>
                                <th>UserId</th>
                                <th>Username</th>
                                <th>PasswordHash</th>
                                <th>Email</th>
                                <th>PhoneNumber</th>
                                <th>Address</th>

                            </tr>
                        </thead>
                        <tbody>
                            {
                                users.map((item) => (
                                    <tr>
                                        <td>{item.userId}</td>
                                        <td>{item.username}</td>
                                        <td>{item.passwordHash}</td>
                                        <td>{item.email}</td>
                                        <td>{item.phoneNumber}</td>
                                        <td>{item.address}</td>
                                    </tr>
                                ))
                            }
                        </tbody>
                    </table>
                </div>
            </div>

        </div>
    )
}
export default ShowDataUser