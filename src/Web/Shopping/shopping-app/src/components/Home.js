import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { UserConsumer } from '../contexts/UserContext';
import { authService } from '../services/auth.service';


export class Home extends Component {
    constructor(props){
        super(props)
        this.state = {
            b2cLoginUrl: '',
            test: {
                success: null,
                loading: null,
                data: null,
                error: null
            }
        }
    }
    componentDidMount(){
        this.setState({ b2cLoginUrl: authService.getB2cLoginUrl()})
    }
    clickHandler = async event => {
        this.setState({ 
            test: {
                loading: true,
            } 
        })  
        const btn = event.target
        btn.disabled = true
        btn.innerHTML = "Testing.."
        const data = await authService.testapi()
        if(data === null) {
            this.setState({ 
                test: {
                    error: 'Could not contact server',
                    loading: false,
                    success: false
                } 
            })
        }
        else if(typeof data === 'string'){
            this.setState({ 
                test: {
                    error: data,  //failed response error
                    loading: false,
                    success: false
                } 
            })    
        }
        else{
            this.setState({ 
                test: {
                    data: data, 
                    loading: false,
                    success: true
                } 
            }) 
        }
        btn.disabled = false
        btn.innerHTML = "Test api call"
    }
    
    render() {
        const {test,b2cLoginUrl} = this.state
        return (
            <UserConsumer>
                {({ auth }) => (
                    <Container>
                    {!auth 
                    ? <p>
                        Please&nbsp;<a disabled={b2cLoginUrl.length > 0} href={b2cLoginUrl}>sign in</a>&nbsp;to access the api.
                    </p>
                : <div>
                    <p>
                        You are now signed in.
                    </p>
                    <button type="button" onClick={this.clickHandler} className="btn btn-primary">
                        Test api call
                    </button>
                    <div className="py-5" hidden={test.loading === null}>
                        {test.loading === true
                        ? <p>Loading...</p>
                        : !test.success 
                        ? <p className="text-danger">{test.error}</p>
                        : JSON.stringify(test.data)}
                    </div>
                </div>}
                    </Container>
                )}
            </UserConsumer>
        );
    }
}