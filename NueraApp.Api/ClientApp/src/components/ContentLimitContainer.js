import React, { Component } from 'react';
import { AddContentLimitItem } from './AddContentLimitItem';
import { ContentLimitCategories } from './ContentLimitCategories';


export class ContentLimitContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            categories: [],
            itemsDictionary: {},
        }
        
        this.getCategories = this.getCategories.bind(this);
        this.getItems = this.getItems.bind(this);
        this.getItemsForCategory = this.getItemsForCategory.bind(this);
        this.componentDidMount = this.componentDidMount(this);
        this.onNotifiedByChild = this.onNotifiedByChild.bind(this);
    }

    getCategories() {
        if (this.state.categories.length > 0) {
            return;
        }

        fetch('/ContentLimit/Categories')
            .then(response => response.json())
            .then(commits => {
                this.setState({ categories: commits });
                this.getItems(commits);
            });
                
    }

    getItems(categories) {
        categories.map((category, categoryIndex) => {
            this.getItemsForCategory(category.id);
        });               
    }

    getItemsForCategory(categoryId) {
        fetch('/ContentLimit/Items?categoryId=' + categoryId)
            .then(response => response.json())
            .then(commits => {
                let tempDict = this.state.itemsDictionary;
                tempDict[categoryId] = commits;
                this.setState({ itemsDictionary: tempDict });
            });
    }

    componentDidMount() {
        this.getCategories();
    }

    onNotifiedByChild(categoryId) {
        this.getItemsForCategory(categoryId);
    }

    render() {
        return (
            <div>
                <ContentLimitCategories categories={this.state.categories} itemsDictionary={this.state.itemsDictionary} updateNotification={this.onNotifiedByChild} />
                <AddContentLimitItem updateNotification={this.onNotifiedByChild} />
            </div>
        );
    }
}
