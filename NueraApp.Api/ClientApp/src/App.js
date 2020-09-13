import React, { Component } from 'react';
import { ContentLimitCategory } from './components/ContentLimitCategory';
import { AddContentLimitItem } from './components/AddContentLimitItem';

import './custom.css'

export default class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            categories: []
        }
        this.getCategories = this.getCategories.bind(this);
        this.componentDidMount = this.componentDidMount(this);
        this.handleToUpdate = this.handleToUpdate.bind(this);
    }

    async getCategories() {
        await fetch('/ContentLimit/Categories', {
            method: 'GET'
        }).then(response => response.json())
          .then(result => this.setState({ categories: result }));
    }

    componentDidMount() {
        this.getCategories();
    }

    handleToUpdate() {
        //alert("notified by handleToUpdate");
        this.getCategories();
    }

    render() {
        //alert("App.render");
        return (
            <div>
                {this.state.categories.map((category, categoryIndex) => {
                    return (<div>
                                <ContentLimitCategory categoryName={category.categoryName} categoryId={category.id} totalValue="0" />
                            </div>)
                })}
                <AddContentLimitItem handleToUpdate={this.handleToUpdate} />
            </div>
        );
    }
}
