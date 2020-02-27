    import React, { Component } from 'react';

export class AddCustomerA extends Component {
        constructor(props) {
            super(props);
            this.onChangeFirstName = this.onChangeFirstName.bind(this);
            this.onChangeLastName = this.onChangeLastName.bind(this);
            this.onChangeAddress = this.onChangeAddress.bind(this);
            this.onChangePersonalNumber = this.onChangePersonalNumber.bind(this);
            this.onSubmit = this.onSubmit.bind(this);

            this.state = {
                firstName: '',
                lastName: '',
                address: '',
                personalNumber: '',
                isError: false,
                messageError: ''
            }
        }
    onChangeFirstName(e) {
            this.setState({
                firstName: e.target.value
            });
        }
        onChangeLastName(e) {
            this.setState({
                lastName: e.target.value
            })
        }
        onChangeAddress(e) {
            this.setState({
                address: e.target.value
            })
        }
        onChangePersonalNumber(e) {
            this.setState({
                personalNumber: e.target.value
            })
        }

        onSubmit(e) {
            e.preventDefault();
            //addCustomer({
            //    firstName: this.state.firstName,
            //    lastName: this.state.lastName,
            //    address: this.state.address,
            //    personalNumber: this.state.personalNumber
            //})
            this.setState({ isError: false, messageError: '' });
            fetch('https://localhost:5001/api/customer/acustomer', {
                method: 'post',
                body: JSON.stringify({
                    firstName: this.state.firstName,
                    lastName: this.state.lastName,
                    address: this.state.address,
                    personalNumber: this.state.personalNumber
                }),
                headers: {
                    'Content-Type': 'application/json',
                }
            }).then((response) => {
                console.log(response);
                response.json();

                if (response.status === 200) {
                    this.props.history.push('/customer');
                } else {
                    console.log(response.message);
                    this.setState({ isError: true, messageError: "Required fields is empty" });
                }
                
                console.log(response);
            });

            this.setState({
                firstName: '',
                lastName: '',
                address: '',
                personalNumber: ''
            })
        }

    render() {
        let message = this.state.isError ? (<div className="alert alert-danger" role="alert">{this.state.messageError}</div>) : '';
            return (
                <div style={{ marginTop: 10 }}>
                    <h3>Add New Customer</h3>
                    {message}
                    <form onSubmit={this.onSubmit}>
                        <div className="form-group">
                            <label>Add First Name:  </label>
                            <input type="text" className="form-control" onChange={this.onChangeFirstName} value={this.state.FirstName} />
                        </div>
                        <div className="form-group">
                            <label>Add Last Name: </label>
                            <input type="text" className="form-control" onChange={this.onChangeLastName} value={this.state.lastName} />
                        </div>
                        <div className="form-group">
                            <label>Address: </label>
                            <input type="text" className="form-control" onChange={this.onChangeAddress} value={this.state.address} />
                        </div>
                        <div className="form-group">
                            <label>Personal Number: </label>
                            <input type="text" className="form-control" onChange={this.onChangePersonalNumber} value={this.state.personalNumber} />
                        </div>
                        <div className="form-group">
                            <input type="submit" value="Register Business" className="btn btn-primary" />
                        </div>
                    </form>
                </div>
            )
        }

        async addCustomer(customer) {
            await fetch('https://localhost:5001/api/customer/acustomer', {
                method: 'post',
                body: JSON.stringify(customer),
                headers: {
                    'Content-Type': 'application/json',
                }
            }).then((response) => response.json()).then((responseJson) => {
                this.props.history.push('/api/customer');
            }).then(res => {
                this.setState({ isError: true, messageError: res.data});
            });
        }
    }