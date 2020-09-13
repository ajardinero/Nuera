import React, { Component } from 'react';
import { ContentLimitItem } from './ContentLimitItem';


export class ContentLimitCategory extends Component {
    constructor(props) {
        super(props);
        this.state = {
            items: [],
            totalValue: 0
        }
        this.getContentLimitItems = this.getContentLimitItems.bind(this);
        this.getTotalValue = this.getTotalValue.bind(this);
        this.handleToUpdate = this.handleToUpdate.bind(this);
        this.componentDidMount = this.componentDidMount(this);
    }

    async getContentLimitItems() {
        alert("getContentLimitItems");
        await fetch('/ContentLimit/Items?categoryId=' + this.props.categoryId, {
            method: 'GET'
        }).then(response => response.json())
          .then(result => this.setState({ items: result, totalValue: this.getTotalValue(result) }));        
    }

    getTotalValue(contentLimitItems) {
        let total = contentLimitItems.reduce((sum, current) => sum + current.value, 0);
        return total;
    }

    handleToUpdate() {
        //alert("handleToUpdate");
        this.getContentLimitItems();
    }

    componentDidMount() {
        this.getContentLimitItems();
    }

    render() {
        //alert("ContentLimitCategory.render");
        return (
            <div>
                <h1>{this.props.categoryName}     {this.state.totalValue} </h1>
                {this.state.items.map((item, itemIndex) => {
                    return (<div>
                                <ContentLimitItem itemId={item.id} name={item.name} value={item.value} handleToUpdate={this.handleToUpdate} />
                            </div>)
                })}
            </div>
        );
    }
}