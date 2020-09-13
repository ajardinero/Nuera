import React, { Component } from 'react';
import { ContentLimitItems } from './ContentLimitItems';


export class ContentLimitCategories extends Component {
    constructor(props) {
        super(props);
        this.state = {
            categories: [],
            itemsDictionary: {},
        }
        this.notifyParent = this.props.updateNotification;
        this.getTotalValue = this.getTotalValue.bind(this);
        this.onNotifiedByChild = this.onNotifiedByChild.bind(this);
    }

    static getDerivedStateFromProps(nextProps, prevState) {
        return {
            categories: nextProps.categories,
            itemsDictionary: nextProps.itemsDictionary
        };
    }

    getTotalValue(categoryId) {
        if (this.state.itemsDictionary[categoryId] === undefined) {
            return 0;
        }        
        return this.state.itemsDictionary[categoryId].reduce((sum, current) => sum + current.value, 0);
    }

    onNotifiedByChild(categoryId) {
        this.notifyParent(categoryId);
    }

    render() {
        return (            
            <div>
                {this.state.categories.map((category, categoryIndex) => {
                    return (
                        <div>
                            <h1>{category.categoryName}     {this.getTotalValue(category.id)} </h1>
                            <ContentLimitItems categoryId={category.id} itemsDictionary={this.state.itemsDictionary} updateNotification={this.onNotifiedByChild} />    
                        </div>)
                })}
            </div>
        );
    }
}