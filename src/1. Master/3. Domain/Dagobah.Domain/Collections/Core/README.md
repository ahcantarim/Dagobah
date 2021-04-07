## BaseCollection

Foi criada uma base para as coleções, para não ter que ficar replicando código.

Agora basta criar uma classe e para transformá-la em uma coleção, basta herdar de **BaseCollection**.

Precisamos ter controle dos métodos *Add*, *Remove* e *Clear*, pois são os métodos que podem passar por uma regra de negócio. Neste caso, colocamos como *virtual*, para que possam ser sobrescritos.

Utilizamos o *ICollection&lt;T&gt;*, pois ele é a menor coleção que o *Entity Framework* aceita.