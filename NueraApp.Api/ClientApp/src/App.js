import React, { Component } from 'react';
import { ContentLimitContainer } from './components/ContentLimitContainer';

import './custom.css'

export default class App extends Component {
    constructor(props) {
        super(props);
        this.state = {            
        }
    }   

    render() {
        //alert("App.render " + this.state.categories.length);
        return (
            <div>
                <ContentLimitContainer />
            </div>
        );
    }
}
