import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './NavMenu.css'
import { Container, NavbarToggler, NavbarBrand, NavLink, Navbar } from 'reactstrap';
import { UserConsumer } from '../../contexts/UserContext';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTimes, faBars, faSignOutAlt, faSignInAlt, faUsers } from '@fortawesome/free-solid-svg-icons';
import { authService } from '../../services/auth.service';

export default class NavMenu extends Component {
    constructor(props) {
        super(props);
        this.state = {
            collapsed: true,
            navHeight: 56,
            b2cLoginUrl: null
        };
    }

    componentDidMount(){
        this.setState({b2cLoginUrl: authService.getB2cLoginUrl()})
    }

    toggleNavbar = () => {
        this.setState({
            collapsed: !this.state.collapsed
        })
    }

    collapseNavbar = () => {
        this.setState({ collapsed: true })
    }

    render(){
        const {b2cLoginUrl,navHeight, collapsed} = this.state
        return(
            <UserConsumer>
            {({ auth }) => (
            <section className="main-nav-header" style={{paddingTop: navHeight + 'px'}}>
                <Navbar className="main-nav navbar navbar-expand-lg fixed-top navbar-light shadow bg-light p-3">
                    <Container>
                        <NavbarBrand className="mr-auto mr-lg-0" tag={Link} to="/" onClick={this.collapseNavbar}>
                            <FontAwesomeIcon icon={faUsers} /> CRM Platform
                        </NavbarBrand>
                        <NavbarToggler className="p-2 border-0" onClick={this.toggleNavbar}>
                            <FontAwesomeIcon icon={collapsed ? faBars : faTimes} />
                        </NavbarToggler>
                        <div style={{ top: navHeight + 'px' }} 
                        className={'navbar-collapse offcanvas-collapse bg-light '.concat(!collapsed ? ' open' : '')} 
                        id="navbarsExampleDefault">
                            <ul className="navbar-nav ml-auto">
                                <li className="nav-item">
                                    <NavLink tag={Link} hidden={!auth} to={'sign-out'}>
                                        <FontAwesomeIcon icon={faSignOutAlt} />&nbsp;Sign out
                                    </NavLink>
                                    <a className="nav-link" hidden={auth} href={b2cLoginUrl} disabled={b2cLoginUrl === null}>
                                        <FontAwesomeIcon icon={faSignInAlt} />&nbsp;Sign in
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </Container>
                </Navbar>
            </section> 
            )}
            </UserConsumer>           
        )
    }
}