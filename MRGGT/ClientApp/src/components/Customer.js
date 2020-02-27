import React, { Component } from 'react';

export class Customer extends Component {
    constructor(props) {
        super(props);
        this.state = { customers: [], loading: true };
    }

    componentDidMount() {
        this.populateCustomersData();
    }

    static renderCustomersTable(customers) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>First name</th>
                        <th>Las Name</th>
                        <th>Address</th>
                    </tr>
                </thead>
                <tbody>
                    {customers.map(customer =>
                        <tr key={customer.ID}>
                            <td>{customer.firstName}</td>
                            <td>{customer.lastName}</td>
                            <td>{customer.address}</td>
                        </tr>
                    )}
                </tbody>
            </table>
            );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Customer.renderCustomersTable(this.state.customers);

        return (
            <div>{contents}</div>
            );
    }

    async populateCustomersData() {
        const response = await fetch('https://localhost:5001/api/customer');
        const data = await response.json();
        this.setState({ customers: data, loading: false });

        //await fetch('https://localhost:5001/api/customer/acustomer', {
        //    method: 'post',
        //    body: JSON.stringify({
        //        "FirstName": "charles",
        //        "LastName": "santos",
        //        "Address": "rua 1",
        //        "PersonalNumber": "062"
        //    }),
        //    headers: {
        //        'Content-Type': 'application/json',
        //    }
        //}).then((response) => response.json())
        //    .then((responseJson) => {
        //        //alert(responseJson);
        //    });
    }
}