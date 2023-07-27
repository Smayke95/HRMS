import 'package:flutter/material.dart';

import 'responsive.dart';

class Search extends StatelessWidget {
  final String buttonText;
  final Function()? buttonOnPressed;

  final bool hideSearch;
  final Function(String)? onSearch;

  const Search(this.buttonText, this.buttonOnPressed,
      {this.hideSearch = false, this.onSearch, super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 50,
      margin: const EdgeInsets.only(bottom: 20),
      child: Row(children: [
        if (!hideSearch)
          SizedBox(
            width: 300,
            child: TextField(
                decoration: const InputDecoration(
                  labelText: "Pretraga",
                  prefixIcon: Icon(Icons.search),
                ),
                onChanged: onSearch),
          ),
        Expanded(
          child: Container(),
        ),
        if (!Responsive.isMobile(context))
          ElevatedButton.icon(
            icon: const Icon(Icons.add),
            style: const ButtonStyle(
              padding: MaterialStatePropertyAll(
                  EdgeInsets.only(left: 20, top: 20, right: 20, bottom: 20)),
            ),
            label: Text(buttonText),
            onPressed: buttonOnPressed,
          ),
      ]),
    );
  }
}
