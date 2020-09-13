import React, { Component } from 'react';


export class ContentLimitItem extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isMounted: false
        }
        this.handleToUpdate = this.props.handleToUpdate;
        this.onChange = this.onChange.bind(this);
        //this.componentWillUnmount = this.componentWillUnmount.bind(this);
        this.onDelete = this.onDelete.bind(this);
        //this.sayHello = this.sayHello.bind(this);
    }

    onChange(){
        this.handleToUpdate();
    }

    //componentWillUnmount(){
    //    this.onChange();
    //}

    //componentDidMount() {
    //    this.onChange();
    //}

    async onDelete(){
        //alert('onDelete ' + this.props.itemId);
        await fetch('ContentLimit/Items/' + this.props.itemId, {
            method: 'DELETE'
        });
        this.onChange();
    }

    //sayHello() {
    //    alert('Hello!');
    //    this.handleToUpdate();
    //}

    render() {
        alert("itemId=" + this.props.itemId + " " + "name=" + this.props.name + " " + "value=" + this.props.value);
        //alert("ContentLimitItem.render");
        
        return (
            <div>
                <div>{this.props.name}  {this.props.value} <button onClick={this.onDelete}>Delete</button></div>
            </div>
        );
    }
}